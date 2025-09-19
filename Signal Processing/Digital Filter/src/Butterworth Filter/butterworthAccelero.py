import numpy as np
import matplotlib.pyplot as plt
from scipy.signal import butter, lfilter
import os

# Konfigurasi sampling
fs = 1000  # Frekuensi sampling dalam Hz

# Path relatif ke file toe.txt dari folder skrip saat ini
file_path = os.path.join("data/toe.txt")  # naik satu level dari 'Butterworth Filter' ke 'Digital Filter'

# Memuat data dari file
try:
    y = np.loadtxt(file_path)
except FileNotFoundError:
    print(f"File 'toe.txt' tidak ditemukan di path: {file_path}")
    exit()

# Membuat vektor waktu
t = np.arange(0, len(y) / fs, 1 / fs)

# Fungsi untuk membuat filter Butterworth low-pass
def buat_filter_lowpass(cutoff, fs, order=5):
    nyquist = 0.5 * fs
    normal_cutoff = cutoff / nyquist
    b, a = butter(order, normal_cutoff, btype='low', analog=False)
    return b, a

# Parameter filter
frekuensi_cutoff = 100  # dalam Hz
b, a = buat_filter_lowpass(frekuensi_cutoff, fs)

# Menerapkan filter ke sinyal
y_terfilter = lfilter(b, a, y)

# Menampilkan hasil dengan plot
plt.figure(figsize=(14, 6))
plt.plot(t, y, label='Sinyal Asli')
plt.plot(t, y_terfilter, label='Sinyal Setelah Filter Low-Pass')
plt.xlabel('Waktu [detik]')
plt.ylabel('Amplitudo')
plt.title('Filter Butterworth Low-Pass')
plt.grid(True)
plt.legend()
plt.tight_layout()
plt.show()