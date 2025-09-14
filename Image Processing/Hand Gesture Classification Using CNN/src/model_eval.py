import tensorflow as tf
from src.augmentation_and_split import create_image_generators

def evaluate_model(model_path: str, data_dir: str):
    model = tf.keras.models.load_model(model_path)
    _, val_gen = create_image_generators(data_dir)
    loss, acc = model.evaluate(val_gen)
    print(f"Validation Accuracy: {acc*100:.2f}%")
    return acc
