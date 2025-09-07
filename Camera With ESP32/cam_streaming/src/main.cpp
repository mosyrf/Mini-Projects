#include <Arduino.h>
#include "esp_camera.h"
#define CAMERA_MODEL_DFRobot_FireBeetle2_ESP32S3
#include "camera_pins.h"

#include <WiFi.h>
#include "esp_http_server.h"
// ================== KONFIGURASI WIFI ==================
#define WIFI_SSID "SUHARNO"
#define WIFI_PASS "Suharno090970"

#include "DFRobot_AXP313A.h"
DFRobot_AXP313A axp;

#include <SPI.h>
#include <TFT_eSPI.h>         
TFT_eSPI tft = TFT_eSPI();     
#include <TJpg_Decoder.h>

bool tft_output(int16_t x, int16_t y, uint16_t w, uint16_t h, uint16_t* bitmap);
static esp_err_t stream_handler(httpd_req_t *req);
void startCameraServer();

void setup() {
  delay(3000);
  Serial.begin(115200);
  Serial.setDebugOutput(false);
  Serial.println();

  // ==== Power Management IC ====
  while (axp.begin() != 0)
  {
    Serial.println("init error");
    delay(1000);
  }
  axp.enableCameraPower(axp.eOV2640);
 
  // ==== TFT Init ====
  tft.init();
  tft.setRotation(1); // Sesuaikan orientasi
  tft.fillScreen(TFT_BLACK);
  tft.setTextColor(TFT_WHITE);
  tft.setTextSize(2);
  tft.setCursor(0, 0, 2);
  Serial.println("TFT initialized");
 
  TJpgDec.setCallback(tft_output);
  TJpgDec.setSwapBytes(true);

  // Init WiFi
  WiFi.begin(WIFI_SSID, WIFI_PASS);
  Serial.print("Connecting to WiFi");
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("\nWiFi connected");
  Serial.print("ESP32-CAM IP: ");
  Serial.println(WiFi.localIP());

    // ==== Kamera Init ====
  camera_config_t config;
  config.ledc_channel = LEDC_CHANNEL_0;
  config.ledc_timer = LEDC_TIMER_0;
  config.pin_d0 = Y2_GPIO_NUM;
  config.pin_d1 = Y3_GPIO_NUM;
  config.pin_d2 = Y4_GPIO_NUM;
  config.pin_d3 = Y5_GPIO_NUM;
  config.pin_d4 = Y6_GPIO_NUM;
  config.pin_d5 = Y7_GPIO_NUM;
  config.pin_d6 = Y8_GPIO_NUM;
  config.pin_d7 = Y9_GPIO_NUM;
  config.pin_xclk = XCLK_GPIO_NUM;
  config.pin_pclk = PCLK_GPIO_NUM;
  config.pin_vsync = VSYNC_GPIO_NUM;
  config.pin_href = HREF_GPIO_NUM;
  config.pin_sscb_sda = SIOD_GPIO_NUM;
  config.pin_sscb_scl = SIOC_GPIO_NUM;
  config.pin_pwdn = PWDN_GPIO_NUM;
  config.pin_reset = RESET_GPIO_NUM;
 
  config.xclk_freq_hz = 20000000; // 20 MHz
  config.frame_size = FRAMESIZE_QVGA; // 320x240
  config.pixel_format = PIXFORMAT_JPEG; // JPEG output
  config.jpeg_quality = 12; // 0 = best, 63 = worst
  config.fb_count = 2; // gunakan double buffer jika ada PSRAM
 
  if (psramFound()) {
    config.fb_location = CAMERA_FB_IN_PSRAM;
  } else {
    config.fb_location = CAMERA_FB_IN_DRAM;
  }
 
  // start camera
  if (esp_camera_init(&config) != ESP_OK) {
    Serial.println("Camera init failed");
    while (true) delay(100);
  }
  // Start WebServer
  startCameraServer();
}

void loop() {
  camera_fb_t * fb = esp_camera_fb_get();
  if (!fb) {
    Serial.println("Camera capture failed");
    return;
  }
 
  // ==== Crop tengah jika QVGA (320x240) → 240x240 ====
  if (fb->width == 320 && fb->height == 240) {
    // Karena TJpgDec tidak otomatis crop, kita gambar dengan offset -40 px agar bagian tengah pas
    TJpgDec.drawJpg(-40, 0, fb->buf, fb->len);
  } else {
    TJpgDec.drawJpg(0, 0, fb->buf, fb->len);
  }
 
  esp_camera_fb_return(fb);
}

// ==== Callback TJpg_Decoder ====
bool tft_output(int16_t x, int16_t y, uint16_t w, uint16_t h, uint16_t* bitmap) {
  tft.pushImage(x, y, w, h, bitmap);
  return true;
}
 
// ---------- WEBSERVER HANDLER ----------
static esp_err_t stream_handler(httpd_req_t *req) {
  camera_fb_t * fb = NULL;
  esp_err_t res = ESP_OK;
  char part_buf[64];
 
  res = httpd_resp_set_type(req, "multipart/x-mixed-replace;boundary=frame");
  if(res != ESP_OK) return res;
 
  while(true) {
    fb = esp_camera_fb_get();
    if (!fb) {
      Serial.println("Camera capture failed");
      return ESP_FAIL;
    }
 
    // Kirim frame ke browser (MJPEG)
    size_t hlen = snprintf(part_buf, 64, "--frame\r\nContent-Type: image/jpeg\r\nContent-Length: %u\r\n\r\n", fb->len);
    res = httpd_resp_send_chunk(req, part_buf, hlen);
    if(res == ESP_OK) res = httpd_resp_send_chunk(req, (const char *)fb->buf, fb->len);
    if(res == ESP_OK) res = httpd_resp_send_chunk(req, "\r\n", 2);
 
    esp_camera_fb_return(fb);
 
    if(res != ESP_OK) break;
  }
  return res;
}

void startCameraServer() {
  httpd_config_t config = HTTPD_DEFAULT_CONFIG();
  httpd_handle_t server = NULL;
  httpd_uri_t stream_uri = {
    .uri       = "/",
    .method    = HTTP_GET,
    .handler   = stream_handler,
    .user_ctx  = NULL
  };
  if (httpd_start(&server, &config) == ESP_OK) {
    httpd_register_uri_handler(server, &stream_uri);
  }
}