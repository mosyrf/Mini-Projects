#include <Arduino.h>

struct DataPoint {
  float service;
  float smash;
  float blok;
  float pertahanan;
  float serangan;
  int label;
};

struct DistanceLabel {
  float distance;
  int label;
};

DataPoint dataset[20] = {
  { 12, 20, 11, 10,  7, 0 },
  { 14, 25, 14, 14,  9, 2 },
  { 10, 22,  9, 13,  6, 0 },
  { 13, 22, 14, 12,  8, 1 },
  { 15, 22, 11, 12,  6, 0 },
  { 15, 24, 11, 12,  9, 1 },
  { 11, 21, 10, 11,  7, 0 },
  { 12, 18, 13, 14,  7, 0 },
  { 11, 17, 12, 12,  8, 0 },
  { 11, 19, 14, 13,  9, 1 },
  { 11, 18, 11, 11,  7, 0 },
  { 15, 23, 13, 14, 10, 2 },
  { 12, 23, 14, 11,  8, 1 },
  { 13, 23, 12, 11,  8, 1 },
  { 14, 21, 12, 11,  8, 0 },
  { 15, 23, 14, 14,  9, 2 },
  { 15, 17, 11, 12,  7, 0 },
  { 13, 23, 11, 13,  9, 1 },
  { 12, 20,  9, 14,  7, 0 },
  { 11, 20, 13, 11,  7, 0 },
};

void bubbleSort(DistanceLabel arr[], int n);
int knnClassify(float newService, float newSmash, float newBlok, float newPertahanan, float newSerangan, int k);
void displayInputData(float service, float smash, float blok, float pertahanan, float serangan);

void setup() {
  Serial.begin(9600);
  while (!Serial)
    ;
  Serial.println("Klasifikasi Performa Pemain Bola Voli");
  Serial.println("Masukkan data pemain (service, smash, blok, pertahanan, serangan):");
}

void loop() {
  if (Serial.available() > 0) {
    String input = Serial.readStringUntil('\n');
    input.trim();

    // Parsing input
    int indices[4];
    int pos = 0;
    for (int i = 0; i < 4; i++) {
      indices[i] = input.indexOf(',', pos);
      if (indices[i] == -1) {
        Serial.println("Format salah! Gunakan format: service, smash, blok, pertahanan, serangan");
        return;
      }
      pos = indices[i] + 1;
    }

    float newService = input.substring(0, indices[0]).toFloat();
    float newSmash = input.substring(indices[0]+1, indices[1]).toFloat();
    float newBlok = input.substring(indices[1]+1, indices[2]).toFloat();
    float newPertahanan = input.substring(indices[2]+1, indices[3]).toFloat();
    float newSerangan = input.substring(indices[3]+1).toFloat();

    // Tampilkan data input
    displayInputData(newService, newSmash, newBlok, newPertahanan, newSerangan);

    // Konfirmasi sebelum klasifikasi
    Serial.println("\nTekan 'y' untuk melanjutkan klasifikasi atau tombol lain untuk input ulang");
    while (!Serial.available());
    char confirmation = Serial.read();
    if (confirmation != 'y' && confirmation != 'Y') {
      Serial.println("Input dibatalkan. Silakan masukkan data baru...");
      return;
    }

    // Classify with KNN (k = 2)
    int result = knnClassify(newService, newSmash, newBlok, newPertahanan, newSerangan, 2);

    Serial.print("\nHasil Klasifikasi: ");
    switch(result) {
      case 0: Serial.println("Cukup"); break;
      case 1: Serial.println("Baik"); break;
      case 2: Serial.println("Hebat"); break;
    }
    Serial.println("\nMasukkan data pemain berikutnya...");
  }
}

void bubbleSort(DistanceLabel arr[], int n) {
  for (int i = 0; i < n - 1; i++) {
    for (int j = 0; j < n - i - 1; j++) {
      if (arr[j].distance > arr[j + 1].distance) {
        DistanceLabel temp = arr[j];
        arr[j] = arr[j + 1];
        arr[j + 1] = temp;
      }
    }
  }
}

int knnClassify(float newService, float newSmash, float newBlok, float newPertahanan, float newSerangan, int k) {
  DistanceLabel distances[20];
  
  // Calculate Euclidean distance for all features
  for (int i = 0; i < 20; i++) {
    float dService = dataset[i].service - newService;
    float dSmash = dataset[i].smash - newSmash;
    float dBlok = dataset[i].blok - newBlok;
    float dPertahanan = dataset[i].pertahanan - newPertahanan;
    float dSerangan = dataset[i].serangan - newSerangan;
    
    distances[i].distance = sqrt(dService*dService + dSmash*dSmash + dBlok*dBlok + 
                                dPertahanan*dPertahanan + dSerangan*dSerangan);
    distances[i].label = dataset[i].label;
  }

  // Sort by distance
  bubbleSort(distances, 20);

  // Count labels of k nearest neighbors
  int count[3] = {0, 0, 0}; // For labels 0, 1, 2
  for (int i = 0; i < k; i++) {
    count[distances[i].label]++;
  }

  // Find the label with maximum count
  int maxCount = 0;
  int predictedLabel = 0;
  for (int i = 0; i < 3; i++) {
    if (count[i] > maxCount) {
      maxCount = count[i];
      predictedLabel = i;
    }
  }

  return predictedLabel;
}

void displayInputData(float service, float smash, float blok, float pertahanan, float serangan) {
  Serial.println("\n=== Data Input Pemain ===");
  Serial.print("Service:    "); Serial.println(service);
  Serial.print("Smash:      "); Serial.println(smash);
  Serial.print("Blok:       "); Serial.println(blok);
  Serial.print("Pertahanan: "); Serial.println(pertahanan);
  Serial.print("Serangan:   "); Serial.println(serangan);
  Serial.println("=========================");
}