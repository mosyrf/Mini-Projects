import os
import zipfile

def extract_zip_file(zip_path, extract_to):
    """Mengekstrak file zip jika diperlukan"""
    if not os.path.exists(extract_to):
        os.makedirs(extract_to)
        print(f"Membuat direktori: {extract_to}")
    
    if os.path.exists(zip_path) and not os.listdir(extract_to):
        print("Mengekstrak file zip...")
        with zipfile.ZipFile(zip_path, 'r') as zip_ref:
            zip_ref.extractall(extract_to)
        print("Ekstraksi selesai.")
    else:
        print("File zip tidak ditemukan atau direktori sudah berisi file.")

# Konfigurasi path berdasarkan struktur folder
BASE_DIR = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))  # Root project directory
ZIP_PATH = os.path.join(BASE_DIR, "data", "raw", "gunting-batu-kertas.zip")
EXTRACT_TO = os.path.join(BASE_DIR, "data", "processed")

# Ekstrak file zip
extract_zip_file(ZIP_PATH, EXTRACT_TO)