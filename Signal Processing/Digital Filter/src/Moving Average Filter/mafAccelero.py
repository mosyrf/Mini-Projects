import numpy as np
from scipy.signal import butter, lfilter
import matplotlib.pyplot as plt
import os

# Path relatif ke file toe.txt dari folder skrip saat ini
file_path = os.path.join("data/toe.txt")  # naik satu level dari 'Butterworth Filter' ke 'Digital Filter'

try:
    y = np.loadtxt(file_path)
except FileNotFoundError:
    print("File 'toe.txt' tidak ditemukan. Pastikan file tersebut ada di direktori yang sama dengan script Python.")
    exit()

t = np.arange(len(y))

# MAF Window Filter
def moving_average(signal, window_size):
    return np.convolve(signal, np.ones(window_size)/window_size, mode='same')

# Menerapkan MAF
window_size = 50  # Ukuran jendela untuk filter
y_maf_filtered = moving_average(y, window_size)

# Plotting hasil
plt.figure(figsize=(12, 6))
plt.plot(t, y, label='Original')
plt.plot(t, y_maf_filtered, color='green')
plt.xlabel('Time')
plt.ylabel('Amplitude')
plt.grid(True)
plt.show()