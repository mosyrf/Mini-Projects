import tensorflow as tf

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
