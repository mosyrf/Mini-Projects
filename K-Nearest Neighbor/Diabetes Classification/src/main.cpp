#include <Arduino.h>

struct DataPoint {
  float gulaDarah;
  float tekananDarah;
  int label;
};

struct DistanceLabel {
  float distance;
  int label;
};

DataPoint dataset[10] = {
  { 99,  72, 0 },
  { 110, 92, 0 },
  { 153, 88, 1 },
  { 128, 84, 1 },
  { 88,  68, 0 },
  { 156, 92, 1 },
  { 99,  70, 0 },
  { 109, 60, 0 },
  { 120, 80, 1 },
  { 140, 90, 1 }
};

void bubbleSort(DistanceLabel arr[], int n);
int knnClassify(float newGula, float newTekanan, int k); 

void setup() {
  Serial.begin(9600);
  while (!Serial)
    ;
  Serial.println("Masukkan gula darah dan tekanan darah (format: GULA DARAH, TEKANAN DARAH): ");
}

void loop() {
  if (Serial.available() > 0) {
    String input = Serial.readStringUntil('\n');
    input.trim();

    // Parsing input
    int commaIndex = input.indexOf(',');
    if (commaIndex == -1) {
      Serial.println("Format salah! Gunakan format: GULA DARAH, TEKANAN DARAH");
      return;
    }

    float newGula = input.substring(0, commaIndex).toFloat();
    float newTekanan = input.substring(commaIndex + 1).toFloat();

    // Klasifikasi dengan KNN (k = 3)
    int result = knnClassify(newGula, newTekanan, 3);

    Serial.print("Hasil tes orang ke-11: ");
    Serial.println(result);
    Serial.println("Masukkan data berikutnya...");
  }
}

int knnClassify(float newGula, float newTekanan, int k) {
  DistanceLabel distances[10];
  for (int i = 0; i < 10; i++) {
    float dx = dataset[i].gulaDarah - newGula;
    float dy = dataset[i].tekananDarah - newTekanan;
    distances[i].distance = sqrt(dx * dx + dy * dy);
    distances[i].label = dataset[i].label;
  }

  // Urutkan berdasarkan jarak
  bubbleSort(distances, 10);

  // Hitung mayoritas label dari k terdekat
  int count0 = 0, count1 = 0;
  for (int i = 0; i < k; i++) {
    if (distances[i].label == 0) count0++;
    else count1++;
  }

  return (count1 > count0) ? 1 : 0;
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