from src.model import build_cnn_model
from src.augmentation_and_split import create_image_generators

def train_model(data_dir: str, model_path: str, epochs=10):
    train_gen, val_gen = create_image_generators(data_dir)
    model = build_cnn_model()
    
    history = model.fit(train_gen, validation_data=val_gen, epochs=epochs)
    
    model.save(model_path)
    print(f"Model saved to {model_path}")
    return history
