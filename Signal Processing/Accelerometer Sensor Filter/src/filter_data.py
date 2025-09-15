import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation
import serial
import threading
import queue
import time

class SensorDataReader:
    def __init__(self, port='COM8', baudrate=9600, window_size=10, sampling_rate=100):
        # Konfigurasi serial
        self.ser = None
        self.port = port
        self.baudrate = baudrate

        # Parameter
        self.window_size = window_size
        self.sampling_rate = sampling_rate

        # Queue untuk data
        self.data_queue = queue.Queue(maxsize=10)

        # Inisialisasi buffer
        self.x_raw = np.zeros(window_size)
        self.y_raw = np.zeros(window_size)
        self.z_raw = np.zeros(window_size)

        self.x_filtered = np.zeros(window_size)
        self.y_filtered = np.zeros(window_size)
        self.z_filtered = np.zeros(window_size)

        # Siapkan thread pembaca
        self.stop_thread = False
        self.serial_thread = None

    def _connect_serial(self):
        """Koneksi serial dengan pengaturan ulang"""
        try:
            if self.ser:
                self.ser.close()

            self.ser = serial.Serial(self.port, self.baudrate, timeout=0.1)
            print(f"Terhubung ke {self.port}")

            # Tunggu sedikit untuk stabilisasi
            time.sleep(2)

            # Bersihkan buffer serial
            self.ser.reset_input_buffer()
        except Exception as e:
            print(f"Gagal terhubung: {e}")
            return False
        return True

    def _blackman_window_filter(self, data):
        """Implementasi Blackman Window Filter"""
        # Buat Blackman window
        blackman_window = np.blackman(len(data))
        
        # Normalisasi window untuk mempertahankan amplitudo sinyal
        blackman_window /= blackman_window.sum()

        # Terapkan filter
        return np.convolve(data, blackman_window, mode='same')

    def _read_serial_data(self):
        """Thread untuk membaca data serial"""
        # Pastikan terkoneksi
        if not self._connect_serial():
            return

        while not self.stop_thread:
            try:
                # Baca data jika tersedia
                if self.ser.in_waiting > 0:
                    # Baca satu baris
                    line = self.ser.readline().decode('utf-8').strip()

                    # Validasi data
                    parts = line.split(",")
                    if len(parts) == 3:
                        try:
                            x, y, z = map(float, parts)

                            # Masukkan ke queue jika tidak penuh
                            try:
                                self.data_queue.put((x, y, z), block=False)
                            except queue.Full:
                                pass
                        except ValueError:
                            print(f"Gagal konversi: {line}")
                    else:
                        print(f"Data tidak lengkap: {line}")

                # Sedikit delay untuk mencegah CPU overload
                time.sleep(0.01)

            except Exception as e:
                print(f"Error membaca serial: {e}")
                # Coba reconnect jika error
                time.sleep(1)
                self._connect_serial()

    def start(self):
        """Mulai thread pembaca"""
        self.stop_thread = False
        self.serial_thread = threading.Thread(target=self._read_serial_data, daemon=True)
        self.serial_thread.start()

    def stop(self):
        """Hentikan thread"""
        self.stop_thread = True
        if self.serial_thread:
            self.serial_thread.join()
        if self.ser:
            self.ser.close()

    def setup_plot(self):
        """Siapkan plot untuk visualisasi"""
        # Persiapan grafik
        self.fig, self.axes = plt.subplots(3, 1, figsize=(10, 12))

        # Judul subplot
        self.axes[0].set_title("Sinyal Asli (Sensor Accelerometer)")
        self.axes[1].set_title("Hasil Filter Blackman Window")
        self.axes[2].set_title("Hasil FFT")

        # Konfigurasi subplot raw dan filtered
        for ax in self.axes[:2]:
            ax.grid()
            ax.set_xlim(0, self.window_size)
            ax.set_ylim(0, 1024)

        # Konfigurasi FFT
        self.axes[2].grid()
        self.axes[2].set_xlim(0, self.sampling_rate // 2)
        self.axes[2].set_ylim(0, 1000)

        # Inisialisasi plot
        self.lines_raw = [ax.plot([], [], label=f"Sumbu {axis}")[0] for ax in self.axes[:2] for axis in ['X', 'Y', 'Z']]
        self.fft_lines = [self.axes[2].plot([], [], label=f"Sumbu {axis}")[0] for axis in ['X', 'Y', 'Z']]

        # Tambahkan legenda
        for ax in self.axes:
            ax.legend()

        plt.tight_layout()

    def update_plot(self, frame):
        """Fungsi update untuk animasi"""
        try:
            x, y, z = self.data_queue.get_nowait()

            # Geser buffer
            self.x_raw = np.roll(self.x_raw, -1)
            self.y_raw = np.roll(self.y_raw, -1)
            self.z_raw = np.roll(self.z_raw, -1)

            # Masukkan data baru
            self.x_raw[-1], self.y_raw[-1], self.z_raw[-1] = x, y, z

            # Filter data dengan Blackman Window
            self.x_filtered[:] = self._blackman_window_filter(self.x_raw)
            self.y_filtered[:] = self._blackman_window_filter(self.y_raw)
            self.z_filtered[:] = self._blackman_window_filter(self.z_raw)

            # Update plot raw dan filtered
            for i, data in enumerate([self.x_raw, self.y_raw, self.z_raw]):
                self.lines_raw[i].set_data(np.arange(self.window_size), data)

            for i, data in enumerate([self.x_filtered, self.y_filtered, self.z_filtered]):
                self.lines_raw[i + 3].set_data(np.arange(self.window_size), data)

            # FFT untuk sinyal yang telah difilter
            filtered_data = [self.x_filtered, self.y_filtered, self.z_filtered]
            for i, data in enumerate(filtered_data):
                fft_data = np.abs(np.fft.fft(data))
                fft_freq = np.fft.fftfreq(len(fft_data), 1 / self.sampling_rate)
                self.fft_lines[i].set_data(fft_freq[:self.window_size // 2], fft_data[:self.window_size // 2])

        except queue.Empty:
            pass

        return self.lines_raw + self.fft_lines

    def run(self):
        """Jalankan visualisasi"""
        self.start()
        self.setup_plot()

        self.ani = FuncAnimation(self.fig, self.update_plot, interval=50, blit=True)
        plt.show()
        self.stop()


# Gunakan kelas
if __name__ == "__main__":
    reader = SensorDataReader()
    reader.run()
