import tensorflow as tf
import numpy as np
import os
import argparse
from tensorflow.keras.preprocessing import image

# Untuk file chooser
import tkinter as tk
from tkinter import filedialog

# Untuk tampilin gambar
import matplotlib.pyplot as plt


def predict_image(model_path: str, img_path: str, img_size=(150,150)):
    """Prediksi gambar dan kembalikan label"""
    model = tf.keras.models.load_model(model_path)
    img = image.load_img(img_path, target_size=img_size)
    img_array = image.img_to_array(img) / 255.0
    img_array = np.expand_dims(img_array, axis=0)
    
    pred = model.predict(img_array)
    classes = ['paper', 'rock', 'scissors']
    return classes[np.argmax(pred)], pred


def choose_file():
    """Buka file dialog untuk pilih gambar"""
    root = tk.Tk()
    root.withdraw()  # sembunyikan window utama
    file_path = filedialog.askopenfilename(
        title="Pilih gambar untuk klasifikasi",
        filetypes=[("Image files", "*.jpg;*.jpeg;*.png")]
    )
    return file_path


if __name__ == "__main__":
    MODEL_PATH = "models/rps_cnn.h5"
    
    parser = argparse.ArgumentParser(description="Prediksi gambar gunting-batu-kertas")
    parser.add_argument("--img", type=str, help="Path ke file gambar untuk klasifikasi")
    args = parser.parse_args()

    if args.img and os.path.exists(args.img):
        test_img = args.img
    else:
        test_img = choose_file()
        if not test_img:
            print("❌ Tidak ada file dipilih. Keluar...")
            exit()

    # Prediksi
    label, probs = predict_image(MODEL_PATH, test_img)
    print(f"✅ Prediksi untuk {test_img} → {label}")

    # Tampilkan gambar dengan hasil prediksi
    img = plt.imread(test_img)
    plt.imshow(img)
    plt.title(f"Prediksi: {label}")
    plt.axis("off")
    plt.show()
