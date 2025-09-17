import numpy as np
from scipy.signal import butter, lfilter
import matplotlib.pyplot as plt

# Sampling rate dan waktu
fs = 1000  # Hz
t = np.arange(0, 1000)  # dalam milidetik

# Sinyal gabungan: 50 Hz dan 250 Hz
y = 2 * np.sin(2 * np.pi * 50 * t / fs) + 6 * np.sin(2 * np.pi * 250 * t / fs)

# Fungsi untuk membuat filter Butterworth high-pass
def butter_highpass(cutoff, fs, order=6):
    nyq = 0.5 * fs
    normal_cutoff = cutoff / nyq
    b, a = butter(order, normal_cutoff, btype='high', analog=False)
    return b, a

# Fungsi untuk menerapkan filter ke data
def butter_highpass_filter(data, cutoff, fs, order=6):
    b, a = butter_highpass(cutoff, fs, order=order)
    y = lfilter(b, a, data)
    return y

# Terapkan filter dengan cutoff 200 Hz
cutoff_freq = 200
y_high = butter_highpass_filter(y, cutoff_freq, fs)

# Plot hasilnya
plt.figure(figsize=(10, 6))
plt.plot(t, y_high, color='red')
plt.title('Filter Butterworth Highpass')
plt.xlabel('Waktu (mS)')
plt.ylabel('Amplitudo')
plt.grid(True)
plt.show()