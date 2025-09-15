import tensorflow as tf
import os

def create_image_generators(data_dir: str, img_size=(150, 150), batch_size=32):
    datagen = tf.keras.preprocessing.image.ImageDataGenerator(
        rescale=1.0/255,
        validation_split=0.2,
        rotation_range=20,
        width_shift_range=0.2,
        height_shift_range=0.2,
        shear_range=0.2,
        zoom_range=0.2,
        horizontal_flip=True
    )
    
    train_gen = datagen.flow_from_directory(
        data_dir,
        target_size=img_size,
        batch_size=batch_size,
        subset="training",
        class_mode="categorical"
    )
    val_gen = datagen.flow_from_directory(
        data_dir,
        target_size=img_size,
        batch_size=batch_size,
        subset="validation",
        class_mode="categorical"
    )
    return train_gen, val_gen


def save_augmented_images(data_dir: str, output_dir: str, img_size=(150,150), num_augmented=50):
    """Simpan hasil augmentasi ke folder output_dir"""
    datagen = tf.keras.preprocessing.image.ImageDataGenerator(
        rescale=1.0/255,
        rotation_range=20,
        width_shift_range=0.2,
        height_shift_range=0.2,
        shear_range=0.2,
        zoom_range=0.2,
        horizontal_flip=True
    )

    if not os.path.exists(output_dir):
        os.makedirs(output_dir)

    generator = datagen.flow_from_directory(
        data_dir,
        target_size=img_size,
        batch_size=1,
        class_mode=None,
        shuffle=True,
        save_to_dir=output_dir,   # ✅ simpan ke folder
        save_prefix="aug",
        save_format="jpg"
    )

    # generate & simpan sejumlah gambar
    for i in range(num_augmented):
        next(generator)  # tiap iterasi generate 1 gambar

    print(f"✅ {num_augmented} augmented images saved to {output_dir}")


if __name__ == "__main__":
    DATA_DIR = "data/processed"
    AUG_DIR = "data/augmented"

    # buat generator biasa (untuk training)
    train_gen, val_gen = create_image_generators(DATA_DIR)
    print("Training samples:", train_gen.samples)
    print("Validation samples:", val_gen.samples)

    # simpan contoh hasil augmentasi
    save_augmented_images(DATA_DIR, AUG_DIR, num_augmented=20)
