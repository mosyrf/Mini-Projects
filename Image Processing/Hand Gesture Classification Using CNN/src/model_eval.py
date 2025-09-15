import sys, os
sys.path.append(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

import tensorflow as tf
import matplotlib.pyplot as plt
import seaborn as sns
import numpy as np
from sklearn.metrics import confusion_matrix, classification_report
import os

from src.augmentation_and_split import create_image_generators


def evaluate_model(model_path: str, data_dir: str, history=None):
    # Load model
    model = tf.keras.models.load_model(model_path)
    _, val_gen = create_image_generators(data_dir)

    # Evaluasi
    loss, acc = model.evaluate(val_gen)
    print(f"✅ Validation Accuracy: {acc*100:.2f}%")
    print(f"✅ Validation Loss: {loss:.4f}")

    # --- Plot grafik accuracy/loss ---
    if history is not None:
        plt.figure(figsize=(12, 5))

        # Accuracy
        plt.subplot(1, 2, 1)
        plt.plot(history.history['accuracy'], label='Train Acc')
        plt.plot(history.history['val_accuracy'], label='Val Acc')
        plt.xlabel("Epochs")
        plt.ylabel("Accuracy")
        plt.legend()
        plt.title("Training & Validation Accuracy")

        # Loss
        plt.subplot(1, 2, 2)
        plt.plot(history.history['loss'], label='Train Loss')
        plt.plot(history.history['val_loss'], label='Val Loss')
        plt.xlabel("Epochs")
        plt.ylabel("Loss")
        plt.legend()
        plt.title("Training & Validation Loss")

        plt.tight_layout()
        plt.show()

    # --- Confusion Matrix ---
    val_gen.reset()
    y_true = val_gen.classes
    y_pred = np.argmax(model.predict(val_gen), axis=1)

    cm = confusion_matrix(y_true, y_pred)
    class_labels = list(val_gen.class_indices.keys())

    print("\nClassification Report:")
    print(classification_report(y_true, y_pred, target_names=class_labels))

    plt.figure(figsize=(6, 5))
    sns.heatmap(cm, annot=True, fmt="d", cmap="Blues",
                xticklabels=class_labels, yticklabels=class_labels)
    plt.xlabel("Predicted")
    plt.ylabel("True")
    plt.title("Confusion Matrix")
    plt.show()

    return acc, loss


if __name__ == "__main__":
    DATA_DIR = "data/processed"
    MODEL_PATH = "models/rps_cnn.h5"

    # Catatan: history bisa dilewatkan saat training, 
    # kalau tidak ada, hanya confusion matrix yang muncul.
    evaluate_model(MODEL_PATH, DATA_DIR, history=None)
