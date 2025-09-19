import numpy as np
import matplotlib.pyplot as plt

# 🎵 Parameter sinyal
frekuensi1 = 36
frekuensi2 = frekuensi1 + 5
frekuensi_sampling = 1000
n = np.arange(0, 1000)

# 🔊 Membuat sinyal sinus
sinyal1 = 5 * np.sin(2 * np.pi * frekuensi1 * n / frekuensi_sampling)
sinyal2 = 2 * np.sin(2 * np.pi * frekuensi2 * n / frekuensi_sampling)
sinyal_total = sinyal1 + sinyal2

# 📉 Filter Moving Average
jumlah_titik_window = 36
filter_ma = np.ones(jumlah_titik_window) / jumlah_titik_window
sinyal_ma = np.convolve(sinyal_total, filter_ma, mode='valid')

# 📊 Plot hasil
plt.figure(figsize=(10, 5))
plt.plot(sinyal_total, label='Sinyal Gabungan (x1 + x2)', color='blue')
plt.plot(sinyal_ma, label='Hasil Moving Average', color='red')
plt.title('Filter Moving Average')
plt.xlabel('n (index sampel)')
plt.ylabel('Amplitudo')
plt.legend()
plt.grid(True)
plt.tight_layout()
plt.show()