#include <Arduino.h>
#include <PubSubClient.h>
#include <WiFi.h>

// --- Konfigurasi Kamera (Pastikan Anda memiliki file header ini) ---
#include "esp_camera.h"
#include "board_config.h"
#include "camera_pins.h"

// --- Konfigurasi Power (Hanya jika Anda menggunakan board dengan AXP313A) ---
#include "DFRobot_AXP313A.h"
DFRobot_AXP313A axp;

// --- Konfigurasi Wi-Fi ---
const char *WIFI_SSID = "SUHARNO";
const char *WIFI_PASSWORD = "Suharno090970";

// --- Konfigurasi MQTT ---
const char *MQTT_USER = "mosyrf";
const char *MQTT_PASSWORD = "mosyrfMQTT";
const char *MQTT_SERVER = "broker.avisha.id";
const int MQTT_PORT = 1883;
const char *MQTT_TOPIC = "mosyrf/camera";

// Gunakan WiFiClient untuk koneksi jaringan pada ESP32
WiFiClient espClient;
PubSubClient client(espClient);

// Buffer MQTT harus lebih besar dari ukuran gambar.
const int MQTT_BUFFER_SIZE = 1024 * 30;

void cameraInit();
void connectWifi();
void connectMQTT();
void grabImage();
void buttonConfig();

void setup()
{
    Serial.begin(115200);

    // Inisialisasi Power AXP313A
    // Blok ini hanya perlu dijalankan jika menggunakan hardware dengan chip AXP
    while (axp.begin() != 0)
    {
        Serial.println("AXP313A init error. Memerlukan board power management.");
        delay(1000);
    }
    axp.enableCameraPower(axp.eOV2640);

    connectWifi();
    setTime();
    espClient.setCACert(root_ca);
    client.setBufferSize(MQTT_BUFFER_SIZE);
    client.setServer(MQTT_SERVER, MQTT_PORT);
    cameraInit();

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

    // Konfigurasi Frame Buffer
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

void connectMQTT()
{
    while (!client.connected())
    {
        Serial.print("Mencoba koneksi ke Server MQTT: ");
        Serial.print(MQTT_SERVER);
        Serial.print("...");
        String clientId = "FOMO Model - " + String(random(0xffff), HEX);

        // Menggunakan otentikasi: client.connect(ID, USER, PASS)
        if (client.connect(MQTT_CLIENT_ID, MQTT_USER, MQTT_PASSWORD))
        {
            Serial.println("Terhubung! (Verified)");
        }
        else
        {
            Serial.print("Gagal, rc=");
            Serial.println(client.state());
            Serial.println("Mencoba lagi...");
            // ESP.restart(); // Hapus restart agar lebih mudah di-debug
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

    if (fb->len > MQTT_BUFFER_SIZE)
    {
        Serial.printf("Gambar terlalu besar (%d bytes), dilewati.\n", fb->len);
    }
    else
    {
        Serial.printf("Ukuran gambar: %d bytes. ", fb->len);
        // Publikasikan byte array dengan panjang data
        if (client.publish(MQTT_TOPIC, (const uint8_t *)fb->buf, fb->len))
        {
            Serial.println("Berhasil Diterbitkan!");
        }
        else
        {
            Serial.println("Gagal Diterbitkan! Mencoba sambungkan kembali...");
            // Cek dan sambungkan kembali koneksi MQTT
            if (!client.connected())
            {
                connectMQTT(); // Panggil fungsi untuk mencoba sambungkan ulang
            }
            // Tambahkan delay singkat atau logika retry
            delay(100);
        }
    }

    esp_camera_fb_return(fb);
}

void buttonConfig()
{
    // Tombol terhubung ke INPUT_PULLUP, jadi status LOW saat tombol DITEKAN
    int reading = digitalRead(inBoardButton);

    // Cek apakah tombol sedang DITEKAN (LOW) dan debouncing sudah lewat
    if (reading == LOW && (millis() - lastDebounceTime) > debounceDelay)
    {
        // Ubah status LED (Toggle)
        ledStatus = !ledStatus;

        // Terapkan status baru ke kedua LED
        // Jika ledStatus true: LED MATI (HIGH). Jika ledStatus false: LED NYALA (LOW).
        digitalWrite(led1, ledStatus);
        digitalWrite(led2, ledStatus);

        Serial.print("Tombol Ditekan! LED Status: ");
        Serial.println(ledStatus ? "ON" : "OFF"); // Tampilkan status yang benar (kebalikan dari nilai digital)

        // Catat waktu terakhir penekanan
        lastDebounceTime = millis();

        // Tunggu hingga tombol dilepas sebelum kembali (menghindari tekan ganda)
        while (digitalRead(inBoardButton) == LOW)
        {
            delay(5);
        }
    }
}