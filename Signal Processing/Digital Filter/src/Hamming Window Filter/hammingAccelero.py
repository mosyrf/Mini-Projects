import numpy as np
import matplotlib.pyplot as plt
import os

# Path ke file toe.txt relatif terhadap lokasi script
folder_data = os.path.join("data")  # naik dua level dari folder src
nama_file = os.path.join(folder_data, "toe.txt")

# Fungsi untuk membaca data
def baca_data(path_file):
    try:
        data = np.loadtxt(path_file)
        return data
    except FileNotFoundError:
        print(f"File '{path_file}' tidak ditemukan. Pastikan path sudah benar.")
        exit()

# Fungsi filter Hamming (Moving Average Filter)
def filter_hamming(data, ukuran_jendela):
    jendela = np.hamming(ukuran_jendela)
    jendela_normal = jendela / jendela.sum()
    hasil = np.convolve(data, jendela_normal, mode='same')
    return hasil

# Fungsi plotting
def tampilkan_plot(x, y, judul):
    plt.figure(figsize=(12, 6))
    plt.plot(x, y, color='green')
    plt.title(judul)
    plt.xlabel('Waktu')
    plt.ylabel('Amplitudo')
    plt.grid(True)
    plt.show()

# Main program
if __name__ == "__main__":
    data_asli = baca_data(nama_file)
    waktu = np.arange(len(data_asli))

    ukuran_jendela = 8
    data_terfilter = filter_hamming(data_asli, ukuran_jendela)

    tampilkan_plot(waktu, data_terfilter, 'Hasil Filter Hamming')