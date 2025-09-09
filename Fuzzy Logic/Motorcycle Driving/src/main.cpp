#include <Arduino.h>

//Range suhu udara (fahrenheit)
#define FREEZE_MIN 0
#define FREEZE_MAX 50  // Fungsi turun
#define COOL_MIN 30
#define COOL_PEAK 50
#define COOL_MAX 70  // Segitiga
#define WARM_MIN 50
#define WARM_PEAK 70
#define WARM_MAX 90  // Segitiga
#define HOT_MIN 70
#define HOT_MAX 110  // Fungsi naik

//Range awan (persentase)
#define SUNNY_MIN 0
#define SUNNY_MAX 40  // Fungsi turun
#define CLOUDY_MIN 20
#define CLOUDY_PEAK 50
#define CLOUDY_MAX 80  // Segitiga
#define OVERCAST_MIN 60
#define OVERCAST_MAX 100  // Fungsi naik

// Output kecepatan (singletone)
#define BERHENTI 0
#define PELAN 25
#define SEDANG 50
#define NGEBUT 100

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
  Serial.println("Sistem Deteksi Mood Pengendara Motor Berdasarkan Suhu Udara (Fahrenheit) dan Tingkat Awan (sunny,  cloudy dan overcast) Menggunakan Logika Fuzzy.");
  Serial.println("Masukkan Suhu Udara (°F) dan Tingkat Awan (%) dipisahkan koma (contoh: 25, 60):");
}

void loop() {
  if (Serial.available() > 0) {
    String input = Serial.readStringUntil('\n');
    input.trim();

    // Parsing input
    int commaIndex = input.indexOf(',');
    if (commaIndex == -1) {
      Serial.println("Format salah! Gunakan format: suhu udara, tingkat awan");
      return;
    }

    float suhuUdara = input.substring(0, commaIndex).toFloat();
    float tingkatAwan = input.substring(commaIndex + 1).toFloat();

    // Hitung nilai keanggotaan suhu udara
    float freezing = hitungKeanggotaanRamp(suhuUdara, FREEZE_MIN, FREEZE_MAX, false);
    float cool = hitungKeanggotaanSegitiga(suhuUdara, COOL_MIN, COOL_PEAK, COOL_MAX);
    float warm = hitungKeanggotaanSegitiga(suhuUdara, WARM_MIN, WARM_PEAK, WARM_MAX);
    float hot = hitungKeanggotaanRamp(suhuUdara, HOT_MIN, HOT_MAX, true);

    // Hitung nilai keanggotaan tingkat awan
    float sunny = hitungKeanggotaanRamp(tingkatAwan, SUNNY_MIN, SUNNY_MAX, false);
    float cloudy = hitungKeanggotaanSegitiga(tingkatAwan, CLOUDY_MIN, CLOUDY_PEAK, CLOUDY_MAX);
    float overcast = hitungKeanggotaanRamp(tingkatAwan, OVERCAST_MIN, OVERCAST_MAX, true);

    // Tampilkan derajat keanggotaan
    Serial.println("\n--- Derajat Keanggotaan ---");
    Serial.print("Suhu Udara: ");
    Serial.print(suhuUdara);
    Serial.println(" °F");
    Serial.print("FREEZING: ");
    Serial.println(freezing);
    Serial.print("COOL: ");
    Serial.println(cool);
    Serial.print("WARM: ");
    Serial.println(warm);
    Serial.print("HOT: ");
    Serial.println(hot);

    Serial.println("\nTingkat Awan: " + String(tingkatAwan) + "%");
    Serial.print("SUNNY: ");
    Serial.println(sunny);
    Serial.print("CLOUDY: ");
    Serial.println(cloudy);
    Serial.print("OVERCAST: ");
    Serial.println(overcast);

    // Aplikasikan aturan fuzzy
    float berhenti = 0, pelan = 0, sedang = 0, ngebut = 0;

    // Rule Base
    // Rule 1: Jika FREEZING dan SUNNY -> PELAN
    pelan = max(pelan, min(freezing, sunny));

    // Rule 2: Jika COOL dan SUNNY -> PELAN
    pelan = max(pelan, min(cool, sunny));

    // Rule 3: Jika WARM dan SUNNY -> SEDANG
    sedang = max(sedang, min(warm, sunny));

    // Rule 4: Jika HOT dan SUNNY -> NGEBUT
    ngebut = max(ngebut, min(hot, sunny));

    // Rule 5: Jika FREEZING dan CLOUDY -> BERHENTI
    berhenti = max(berhenti, min(freezing, cloudy));

    // Rule 6: Jika COOL dan CLOUDY -> PELAN
    pelan = max(pelan, min(cool, cloudy));

    // Rule 7: Jika WARM dan CLOUDY -> SEDANG
    sedang = max(sedang, min(warm, cloudy));

    // Rule 8: Jika HOT dan CLOUDY -> NGEBUT
    ngebut = max(ngebut, min(hot, cloudy));

    // Rule 9: Jika FREEZING dan OVERCAST -> BERHENTI
    berhenti = max(berhenti, min(freezing, overcast));

    // Rule 10: Jika COOL dan OVERCAST -> PELAN
    pelan = max(pelan, min(cool, overcast));

    // Rule 11: Jika WARM dan OVERCAST -> SEDANG
    sedang = max(sedang, min(warm, overcast));

    // Rule 12: Jika HOT dan OVERCAST -> NGEBUT
    ngebut = max(ngebut, min(hot, overcast));

    // Defuzzifikasi (Weighted Average Method)
    float numerator = (berhenti * BERHENTI) + (pelan * PELAN) + (sedang * SEDANG) + (ngebut * NGEBUT);
    float denominator = berhenti + pelan + sedang + ngebut;
    float kecepatanMotor = (denominator != 0) ? numerator / denominator : 0;

    // Tampilkan hasil
    Serial.println("\n--- HASIL KECEPATAN ---");
    Serial.print("BERHENTI: ");
    Serial.println(berhenti);
    Serial.print("PELAN: ");
    Serial.println(pelan);
    Serial.print("SEDANG: ");
    Serial.println(sedang);
    Serial.print("NGEBUT: ");
    Serial.println(ngebut);
    Serial.print("\nKecepatan Motor: ");
    Serial.print(kecepatanMotor);
    Serial.println("KM/JAM");

    // Tampilkan rekomendasi
    Serial.println("\n--- REKOMENDASI KECEPATAN ---");
    if (kecepatanMotor >= 0 && kecepatanMotor <= 15) {
      Serial.println("Motor Berhenti (Kecepatan = 0)");

    } else if (kecepatanMotor >= 16 && kecepatanMotor <= 35) {
      Serial.println("Motor Pelan (Kecepatan = 25)");

    } else if (kecepatanMotor >= 36 && kecepatanMotor <= 75) {
      Serial.println("Motor Sedang (Kecepatan = 50)");

    } else {
      Serial.println("Motor Ngebut (Kecepatan = 100)");
    }

    Serial.println("\nMasukkan Suhu Udara dan Tingkat Awan baru (format: suhu udara, tingkat awan):");
  }
}