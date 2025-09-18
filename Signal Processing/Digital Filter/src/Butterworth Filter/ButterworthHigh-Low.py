import numpy as np
import matplotlib.pyplot as plt
from scipy.signal import butter, filtfilt

# 📌 Parameter sinyal
frekuensi_1 = 90            # Frekuensi komponen pertama (Hz)
frekuensi_2 = 10            # Frekuensi komponen kedua (Hz)
frekuensi_sampling = 1000   # Frekuensi sampling (Hz)
durasi = 1                  # Durasi sinyal (detik)
orde_filter = 10            # Orde filter Butterworth

# 🕒 Waktu sampling
t = np.arange(0, durasi, 1 / frekuensi_sampling)

# 🔊 Sinyal gabungan: dua gelombang sinus
sinyal_asli = 5 * np.sin(2 * np.pi * frekuensi_1 * t) + 10 * np.sin(2 * np.pi * frekuensi_2 * t)

# 🧹 Fungsi filter Butterworth
def filter_butterworth(data, cutoff, fs, orde, tipe):
    nyquist = fs / 2
    normal_cutoff = cutoff / nyquist
    b, a = butter(orde, normal_cutoff, btype=tipe, analog=False)
    hasil = filtfilt(b, a, data)
    return hasil

# 🔻 Filter low-pass dan high-pass
sinyal_lowpass = filter_butterworth(sinyal_asli, frekuensi_2, frekuensi_sampling, orde_filter, tipe='low')
sinyal_highpass = filter_butterworth(sinyal_asli, frekuensi_1, frekuensi_sampling, orde_filter, tipe='high')

# 📊 Visualisasi hasil
plt.plot(t, sinyal_asli, label='Sinyal Asli')
plt.plot(t, sinyal_lowpass, label='Low-pass Filter')
plt.plot(t, sinyal_highpass, label='High-pass Filter')
plt.title('Hasil Filter Butterworth Orde 10')
plt.xlabel('Waktu (detik)')
plt.ylabel('Amplitudo')
plt.grid(True)
plt.legend()
plt.tight_layout()
plt.show()