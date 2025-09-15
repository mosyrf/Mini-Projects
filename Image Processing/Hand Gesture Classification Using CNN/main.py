import os
from src.raw_data_extraction import extract_zip_file
from src.augmentation_and_split import save_augmented_images
from src.train import train_model
from src.model_eval import evaluate_model

# Path konfigurasi
BASE_DIR = os.path.dirname(os.path.abspath(__file__))
ZIP_PATH = os.path.join(BASE_DIR, "data", "raw", "gunting-batu-kertas.zip")
PROCESSED_DIR = os.path.join(BASE_DIR, "data", "processed")
AUGMENTED_DIR = os.path.join(BASE_DIR, "data", "augmented")
MODEL_PATH = os.path.join(BASE_DIR, "models", "rps_cnn.h5")


def main():
    print("=== Hand Gesture Classification (Rock-Paper-Scissors) ===")

    # 1. Ekstrak dataset
    extract_zip_file(ZIP_PATH, PROCESSED_DIR)

    # 2. Augmentasi dataset (opsional, bisa di-comment kalau tidak mau simpan hasilnya)
    save_augmented_images(PROCESSED_DIR, AUGMENTED_DIR, num_augmented=20)

    # 3. Training model
    history = train_model(PROCESSED_DIR, MODEL_PATH, epochs=5)

    # 4. Evaluasi model
    evaluate_model(MODEL_PATH, PROCESSED_DIR, history=history)


if __name__ == "__main__":
    main()
