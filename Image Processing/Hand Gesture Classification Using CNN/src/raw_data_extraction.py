import os
import zipfile

def extract_zip_file(zip_path, extract_to):
    """Mengekstrak file zip ke folder target"""

    # Pastikan file zip ada
    if not os.path.exists(zip_path):
        print(f"❌ File zip tidak ditemukan: {zip_path}")
        return
    
    # Buat folder target kalau belum ada
    if not os.path.exists(extract_to):
        os.makedirs(extract_to)
        print(f"Membuat direktori: {extract_to}")

    # Kalau folder kosong → lakukan ekstraksi
    if len(os.listdir(extract_to)) == 0:
        print("📦 Mengekstrak file zip...")
        with zipfile.ZipFile(zip_path, 'r') as zip_ref:
            zip_ref.extractall(extract_to)
        print(f"✅ Ekstraksi selesai ke {extract_to}")
    else:
        print(f"✔️ Dataset sudah ada di {extract_to}, ekstraksi dilewati.")


# Konfigurasi path berdasarkan struktur folder
BASE_DIR = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))  # Root project directory
ZIP_PATH = os.path.join(BASE_DIR, "data", "raw", "gunting-batu-kertas.zip")
EXTRACT_TO = os.path.join(BASE_DIR, "data", "processed")

# Ekstrak file zip
if __name__ == "__main__":
    extract_zip_file(ZIP_PATH, EXTRACT_TO)
