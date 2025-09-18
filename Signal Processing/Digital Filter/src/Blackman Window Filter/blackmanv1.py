import numpy as np
import matplotlib.pyplot as plt

# 🧮 Parameter dasar
sampling_rate = 1000  # Frekuensi sampling (Hz)
duration = 1          # Durasi sinyal (detik)
time = np.arange(0, duration, 1/sampling_rate)  # Waktu dalam detik
filter_length = 36    # Panjang filter Blackman

# 🎵 Membuat sinyal gabungan: 50 Hz dan 500 Hz
signal_original = np.sin(2 * np.pi * 50 * time) + 2 * np.sin(2 * np.pi * 500 * time)

# 🪟 Membuat filter Blackman dan melakukan konvolusi
blackman_window = np.blackman(filter_length)
signal_filtered = np.convolve(signal_original, blackman_window, mode='same')

# 📊 Visualisasi sinyal
plt.figure(figsize=(10, 5))
plt.plot(time, signal_original, label='Sinyal Asli', color='blue', linestyle='-')
plt.plot(time, signal_filtered, label='Setelah Filter Blackman', color='red', linestyle='-')
plt.title('Pemrosesan Sinyal dengan Filter Blackman')
plt.xlabel('Waktu (detik)')
plt.ylabel('Amplitudo')
plt.legend()
plt.grid(True)
plt.tight_layout()
plt.show()