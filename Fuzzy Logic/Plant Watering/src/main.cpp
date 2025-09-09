#include <Arduino.h>

// Definisi range suhu yang diperbaiki
#define DINGIN_MIN 0
#define DINGIN_MAX 15  // Fungsi turun
#define SEJUK_MIN 10
#define SEJUK_PEAK 15
#define SEJUK_MAX 20  // Segitiga
#define NORMAL_MIN 15
#define NORMAL_PEAK 20
#define NORMAL_MAX 25  // Segitiga
#define HANGAT_MIN 20
#define HANGAT_PEAK 25
#define HANGAT_MAX 30  // Segitiga
#define PANAS_MIN 25
#define PANAS_MAX 40  // Fungsi naik

// Definisi range kelembaban
#define KERING_MIN 0
#define KERING_MAX 50  // Fungsi turun
#define SEDANG_MIN 30
#define SEDANG_PEAK 50
#define SEDANG_MAX 70  // Segitiga
#define BASAH_MIN 50
#define BASAH_MAX 100  // Fungsi naik

// Output penyiraman (singleton)
#define TIDAK_SIRAM 0
#define SEDIKIT 15
#define SEDANG 30
#define BANYAK 60

// Fungsi keanggotaan untuk bentuk turun/naik
float hitungKeanggotaanRamp(float nilai, float minVal, float maxVal, bool naik) {
  if (naik) {
    if (nilai <= minVal) return 0;
    if (nilai >= maxVal) return 1;
    return (nilai - minVal) / (maxVal - minVal);
  } else {
    if (nilai <= minVal) return 1;
    if (nilai >= maxVal) return 0;
    return (maxVal - nilai) / (maxVal - minVal);
  }
}

// Fungsi keanggotaan untuk bentuk segitiga
float hitungKeanggotaanSegitiga(float nilai, float minVal, float peak, float maxVal) {
  if (nilai <= minVal || nilai >= maxVal) return 0;
  if (nilai == peak) return 1;
  if (nilai < peak) return (nilai - minVal) / (peak - minVal);
  return (maxVal - nilai) / (maxVal - peak);
}

void setup() {
  Serial.begin(9600);
  Serial.println("Sistem Penyiram Tanaman Otomatis (Fuzzy Logic)");
  Serial.println("Masukkan suhu (°C) dan kelembaban (%) dipisahkan koma (contoh: 25,60):");
}

void loop() {
  if (Serial.available() > 0) {
    String input = Serial.readStringUntil('\n');
    input.trim();

    // Parsing input
    int commaIndex = input.indexOf(',');
    if (commaIndex == -1) {
      Serial.println("Format salah! Gunakan format: suhu, kelembaban");
      return;
    }

    float suhu = input.substring(0, commaIndex).toFloat();
    float kelembaban = input.substring(commaIndex + 1).toFloat();

    // Hitung nilai keanggotaan suhu (dengan fungsi yang sesuai)
    float dingin = hitungKeanggotaanRamp(suhu, DINGIN_MIN, DINGIN_MAX, false);
    float sejuk = hitungKeanggotaanSegitiga(suhu, SEJUK_MIN, SEJUK_PEAK, SEJUK_MAX);
    float normal = hitungKeanggotaanSegitiga(suhu, NORMAL_MIN, NORMAL_PEAK, NORMAL_MAX);
    float hangat = hitungKeanggotaanSegitiga(suhu, HANGAT_MIN, HANGAT_PEAK, HANGAT_MAX);
    float panas = hitungKeanggotaanRamp(suhu, PANAS_MIN, PANAS_MAX, true);

    // Hitung nilai keanggotaan kelembaban
    float kering = hitungKeanggotaanRamp(kelembaban, KERING_MIN, KERING_MAX, false);
    float sedang = hitungKeanggotaanSegitiga(kelembaban, SEDANG_MIN, SEDANG_PEAK, SEDANG_MAX);
    float basah = hitungKeanggotaanRamp(kelembaban, BASAH_MIN, BASAH_MAX, true);

    // Tampilkan derajat keanggotaan
    Serial.println("\n--- Derajat Keanggotaan ---");
    Serial.print("Suhu: ");
    Serial.print(suhu);
    Serial.println(" °C");
    Serial.print("Dingin: ");
    Serial.println(dingin);
    Serial.print("Sejuk: ");
    Serial.println(sejuk);
    Serial.print("Normal: ");
    Serial.println(normal);
    Serial.print("Hangat: ");
    Serial.println(hangat);
    Serial.print("Panas: ");
    Serial.println(panas);

    Serial.println("\nKelembaban: " + String(kelembaban) + "%");
    Serial.print("Kering: ");
    Serial.println(kering);
    Serial.print("Sedang: ");
    Serial.println(sedang);
    Serial.print("Basah: ");
    Serial.println(basah);

    // Aplikasikan aturan fuzzy
    float tidak = 0, sedikit = 0, sedangOut = 0, banyak = 0;

    // Rule Base
    // Jika Dingin DAN Kering -> Sedikit
    sedikit = max(sedikit, min(dingin, kering));
    // Jika Sejuk DAN Kering -> Sedikit
    sedikit = max(sedikit, min(sejuk, kering));
    // Jika Normal DAN Kering -> Sedang
    sedangOut = max(sedangOut, min(normal, kering));
    // Jika Hangat DAN Kering -> Banyak
    banyak = max(banyak, min(hangat, kering));
    // Jika Panas DAN Kering -> Banyak
    banyak = max(banyak, min(panas, kering));
    // Jika Normal DAN Sedang -> Sedikit
    sedikit = max(sedikit, min(normal, sedang));
    // Jika Hangat DAN Sedang -> Sedang
    sedangOut = max(sedangOut, min(hangat, sedang));
    // Jika Panas DAN Sedang -> Banyak
    banyak = max(banyak, min(panas, sedang));
    // Jika Hangat DAN Basah -> Sedikit
    sedikit = max(sedikit, min(hangat, basah));
    // Jika Panas DAN Basah -> Sedang
    sedangOut = max(sedangOut, min(panas, basah));
    // Default: Tidak disiram
    tidak = 1 - max(max(sedikit, sedangOut), banyak);

    // Defuzzifikasi (Weighted Average)
    float numerator = (tidak * TIDAK_SIRAM) + (sedikit * SEDIKIT) + (sedangOut * SEDANG) + (banyak * BANYAK);
    float denominator = tidak + sedikit + sedangOut + banyak;
    float waktuPenyiraman = (denominator != 0) ? numerator / denominator : 0;

    // Tampilkan hasil
    Serial.println("\n--- HASIL PENYIRAMAN ---");
    Serial.print("Tidak: ");
    Serial.println(tidak);
    Serial.print("Sedikit: ");
    Serial.println(sedikit);
    Serial.print("Sedang: ");
    Serial.println(sedangOut);
    Serial.print("Banyak: ");
    Serial.println(banyak);
    Serial.print("\nWaktu Penyiraman: ");
    Serial.print(waktuPenyiraman);
    Serial.println(" detik");

    // Tampilkan rekomendasi
    Serial.println("\n--- REKOMENDASI ---");
    if (waktuPenyiraman >= 0 && waktuPenyiraman <= 10) {
      Serial.println("Tidak perlu menyiram");
    } else if (waktuPenyiraman >= 11 && waktuPenyiraman <= 20) {
      Serial.println("Siram sedikit (15 detik)");
    } else if (waktuPenyiraman >= 21 && waktuPenyiraman <= 40) {
      Serial.println("Siram sedang (30 detik)");
    } else {
      Serial.println("Siram banyak (60 detik)");
    }

    Serial.println("\nMasukkan suhu dan kelembaban baru (format: suhu,kelembaban):");
  }
}