import numpy as np
from scipy.signal import butter, lfilter
import matplotlib.pyplot as plt

# Sampling rate
fs = 10000  # Hz

# Waktu dan sinyal campuran (frekuensi 50 Hz dan 100 Hz)
i = np.arange(0, 1000)
y = np.sin(2 * np.pi * 50 * i / fs) + 3 * np.sin(2 * np.pi * 100 * i / fs)

# Fungsi untuk membuat filter Butterworth High-Pass
def butter_highpass(cutoff, fs, order=8):
    nyq = 0.5 * fs  # frekuensi Nyquist
    normal_cutoff = cutoff / nyq
    b, a = butter(order, normal_cutoff, btype='high', analog=False)
    return b, a

# Terapkan filter
cutoff_freq = 80  # Hz
b_high, a_high = butter_highpass(cutoff_freq, fs)
y_high = lfilter(b_high, a_high, y)

# Plot hasil filter
plt.figure(figsize=(14, 6))
plt.title('Filter Butterworth Highpass')
plt.xlabel('Waktu (mS)')
plt.ylabel('Amplitudo')
plt.grid(True)
plt.plot(i, y_high, label='Sinyal Terfilter')
plt.legend()
plt.show()