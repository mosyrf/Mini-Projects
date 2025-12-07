#include <Arduino.h>
#include <PubSubClient.h>

// --- Konfigurasi Kamera ---
#include "esp_camera.h"
#include "board_config.h"
#include "camera_pins.h"

// --- Konfigurasi Power ---
#include "DFRobot_AXP313A.h"
DFRobot_AXP313A axp;

// --- Konfigurasi Display ---
#include <SPI.h>
#include <TFT_eSPI.h>
TFT_eSPI tft = TFT_eSPI();
#include <TJpg_Decoder.h>

// ====================================================================
// --- Konfigurasi Keamanan ---
// true = Menggunakan SSL (Port 8884, butuh sertifikat & sinkronisasi waktu)
// false = Menggunakan Non-SSL (Port 1883, standar)
// ====================================================================
#define USE_MQTT_SSL false
// ====================================================================

// --- Konfigurasi Wi-Fi ---
#include <WiFi.h>
const char *WIFI_SSID = "SUHARNO";
const char *WIFI_PASSWORD = "Suharno090970";

// --- Konfigurasi MQTT (Umum) ---
const char *MQTT_USER = "mosyrf";
const char *MQTT_PASSWORD = "mosyrfMQTT";
const char *MQTT_SERVER = "broker.avisha.id";
const char *MQTT_TOPIC = "mosyrf/camera";
const char *MQTT_CLIENT_ID_BASE = "ESP32_Camera_Stream";

// Buffer MQTT harus lebih besar dari ukuran gambar.
const int MQTT_BUFFER_SIZE = 1024 * 30; // 30KB

#if USE_MQTT_SSL
#include <WiFiClientSecure.h>
#include <time.h>

const int MQTT_PORT = 8884;
const char *ntpServer = "pool.ntp.org";
const long gmtOffset_sec = 25200; // WIB (UTC+7)
const int daylightOffset_sec = 0;

// --- SERTIFIKAT CA --- (Dibiarkan untuk kebutuhan MQTT SSL)
const char *root_ca = R"EOF(
-----BEGIN CERTIFICATE-----
MIIDtTCCAp2gAwIBAgIUOKMAqMXFCssUwLZtEx+8/dj+d/AwDQYJKoZIhvcNAQEL
BQAwajELMAkGA1UEBhMCSUQxEDAOBgNVBAgMB0pha2FydGExEDAOBgNVBAcMB0ph
a2FydGExDTALBgNVBAoMBEVNUVgxDTALBgNVBAsMBE1RVFQxGTAXBgNVBAMMEGJy
b2tlci5hdmlzaGEuaWQwHhcNMjUxMTAyMTEzODM2WhcNMjYxMTAyMTEzODM2WjBq
MQswCQYDVQQGEwJJRDEQMA4GA1UECAwHSmFrYXJ0YTEQMA4GAk
-----END CERTIFICATE-----
)EOF";

WiFiClientSecure espClient; // Gunakan Client AMAN

#else
// --- Jika SSL TIDAK AKTIF ---
const int MQTT_PORT = 1883;
WiFiClient espClient; // Gunakan Client STANDAR

#endif
// --- Akhir Logika Kondisional ---

// Objek PubSubClient akan menggunakan espClient mana pun yang didefinisikan di atas
PubSubClient client(espClient);

// --- Konfigurasi LED & Push Button ---
const int led1 = 15;
const int led2 = 16;
bool ledStatus = false;

const int inBoardButton = 47;
unsigned long lastDebounceTime = 0;
const unsigned long debounceDelay = 50;

// --- Fungsi Callback Decoder JPEG untuk TFT_eSPI ---
// Wajib ada untuk TJpg_Decoder
bool tft_output(int16_t x, int16_t y, uint16_t w, uint16_t h, uint16_t *bitmap) {
    if (y >= tft.height()) return 0;
    tft.pushImage(x, y, w, h, bitmap);
    return 1;
}

// --- Deklarasi Fungsi  ---
void cameraInit();
void connectWifi();
void connectMQTT();
void grabImage();
void buttonConfig();
void display_jpeg_to_tft(uint8_t *jpeg_buf, size_t jpeg_len); 

#if USE_MQTT_SSL
void setTime();
#endif

void setup()
{
    Serial.begin(115200);

    while (axp.begin() != 0)
    {
        Serial.println("AXP313A init error. Memerlukan board power management.");
        delay(1000);
    }
    axp.enableCameraPower(axp.eOV2640);
    Serial.println("AXP313A Power OK.");

    connectWifi();

// --- Setup SSL ---
#if USE_MQTT_SSL
    Serial.println("Mode SSL: Menyinkronkan waktu...");
    setTime();
    Serial.println("Mode SSL: Mengatur Sertifikat CA...");
    espClient.setCACert(root_ca);
#else
    Serial.println("Mode Non-SSL: Melewatkan pengaturan SSL.");
#endif
    // --- Akhir Setup SSL ---

    client.setBufferSize(MQTT_BUFFER_SIZE);
    client.setServer(MQTT_SERVER, MQTT_PORT);
    cameraInit();

    // --- Inisialisasi TFT ---
    tft.init();
    tft.setRotation(1); 
    tft.fillScreen(TFT_BLACK);
    TJpgDec.setJpgScale(1); 
    TJpgDec.setSwapBytes(true);
    TJpgDec.setCallback(tft_output);
    Serial.println("TFT Display Ready.");
    // -------------------------

    pinMode(led1, OUTPUT);
    pinMode(led2, OUTPUT);
    digitalWrite(led1, ledStatus);
    digitalWrite(led2, ledStatus);

    pinMode(inBoardButton, INPUT_PULLUP);
}
void loop()
{
    buttonConfig();

    if (!client.connected())
    {
        connectMQTT();
    }

    client.loop();
    grabImage();
}

// ====================================================================
// --- Fungsi Tampilan Gambar ke TFT ---
// Menampilkan buffer JPEG ke TFT menggunakan TJpg_Decoder
// ====================================================================
void display_jpeg_to_tft(uint8_t *jpeg_buf, size_t jpeg_len)
{
    if (!jpeg_buf || jpeg_len == 0)
        return;

    // Decoding dan menampilkan JPEG
    // Posisi (0, 0)
    int rc = TJpgDec.drawJpg(0, 0, jpeg_buf, jpeg_len);

    if (rc != 1) {
        Serial.printf("ERR: Gagal decode/draw JPEG: %d\n", rc);
    }
}


void cameraInit()
{
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
    config.pin_sccb_sda = SIOD_GPIO_NUM;
    config.pin_sccb_scl = SIOC_GPIO_NUM;
    config.pin_pwdn = PWDN_GPIO_NUM;
    config.pin_reset = RESET_GPIO_NUM;
    config.xclk_freq_hz = 12000000;
    config.pixel_format = PIXFORMAT_JPEG;

    // Sesuaikan FRAMESIZE agar sesuai dengan resolusi TFT (480x320)
    // FRAMESIZE_HVGA (480x320) akan menjadi ukuran yang pas
    config.frame_size = FRAMESIZE_HVGA;
    config.jpeg_quality = 10;
    config.fb_count = 2;

    esp_err_t err = esp_camera_init(&config);
    if (err != ESP_OK)
    {
        Serial.printf("Camera init failed with error 0x%x", err);
        ESP.restart();
        return;
    }
}

void connectWifi()
{
    Serial.print("Menghubungkan ke WiFi: ");
    Serial.println(WIFI_SSID);
    WiFi.mode(WIFI_STA);
    WiFi.begin(WIFI_SSID, WIFI_PASSWORD);

    while (WiFi.status() != WL_CONNECTED)
    {
        delay(500);
        Serial.print(".");
    }

    Serial.println("\nWiFi Terhubung");
    Serial.print("IP Address: ");
    Serial.println(WiFi.localIP());
}

// ---  hanya akan dikompilasi SSL true ---
#if USE_MQTT_SSL
void setTime()
{
    Serial.print("Menyinkronkan waktu via NTP");
    configTime(gmtOffset_sec, daylightOffset_sec, ntpServer);

    struct tm timeinfo;
    int retry = 0;
    while (!getLocalTime(&timeinfo) && retry < 20)
    {
        Serial.print(".");
        delay(500);
        retry++;
    }

    if (retry < 20)
    {
        Serial.println("\nWaktu Tersinkronisasi!");
        Serial.println(&timeinfo, "%A, %B %d %Y %H:%M:%S");
    }
    else
    {
        Serial.println("\nGagal Sync Waktu (SSL mungkin akan error)");
    }
}
#endif
// --- Akhir Setup SSL ---

void connectMQTT()
{
    while (!client.connected())
    {
#if USE_MQTT_SSL
        Serial.print("Mencoba koneksi Secure MQTT...");
#else
        Serial.print("Mencoba koneksi ke Server MQTT: ");
#endif

        Serial.println(MQTT_SERVER);

        // Buat Client ID unik setiap kali konek untuk menghindari konflik
        String clientId = String(MQTT_CLIENT_ID_BASE) + " - " + String(random(0xffff), HEX);

        if (client.connect(clientId.c_str(), MQTT_USER, MQTT_PASSWORD))
        {
            Serial.println("Terhubung!");
        }
        else
        {
            Serial.print("Gagal, rc=");
            Serial.print(client.state());

// --- Blok Error Khusus SSL ---
#if USE_MQTT_SSL
            char err_buf[100];
            esp_err_t lastErr = espClient.lastError(err_buf, 100);
            if (lastErr != 0)
            {
                Serial.print(" | SSL Error: ");
                Serial.println(err_buf);
            }
#endif
            // --- Akhir Setup SSL ---

            Serial.println(" Mencoba lagi dalam 3 detik...");
            delay(3000);
        }
    }
}

void grabImage()
{
    if (!client.connected())
    {
        return;
    }

    camera_fb_t *fb = NULL;
    fb = esp_camera_fb_get();

    if (!fb || fb->format != PIXFORMAT_JPEG)
    {
        Serial.println("Gagal menangkap gambar JPEG");
        if (fb)
            esp_camera_fb_return(fb);
        return;
    }

    // --- Tampilkan Gambar ke TFT ---
    display_jpeg_to_tft(fb->buf, fb->len);
    // ------------------------------

    if (fb->len > MQTT_BUFFER_SIZE)
    {
        Serial.printf("Gambar terlalu besar (%d bytes), dilewati dari MQTT.\n", fb->len);
    }
    else
    {
        Serial.printf("Ukuran gambar: %d bytes. ", fb->len);
        if (client.publish(MQTT_TOPIC, (const uint8_t *)fb->buf, fb->len))
        {
            Serial.println("Berhasil Diterbitkan!");
        }
        else
        {
            Serial.println("Gagal Diterbitkan! Mencoba sambungkan kembali...");
            delay(100);
        }
    }

    esp_camera_fb_return(fb);
}

void buttonConfig()
{
    int reading = digitalRead(inBoardButton);

    if (reading == LOW && (millis() - lastDebounceTime) > debounceDelay)
    {
        ledStatus = !ledStatus;

        digitalWrite(led1, ledStatus);
        digitalWrite(led2, ledStatus);

        Serial.print("Tombol Ditekan! LED Status: ");
        Serial.println(ledStatus ? "ON" : "OFF");

        lastDebounceTime = millis();

        // Tunggu hingga tombol dilepas
        while (digitalRead(inBoardButton) == LOW)
        {
            delay(5);
        }
    }
}