import tensorflow as tf
import numpy as np
from tensorflow.keras.preprocessing import image

def predict_image(model_path: str, img_path: str, img_size=(150,150)):
    model = tf.keras.models.load_model(model_path)
    img = image.load_img(img_path, target_size=img_size)
    img_array = image.img_to_array(img) / 255.0
    img_array = np.expand_dims(img_array, axis=0)
    
    pred = model.predict(img_array)
    classes = ['paper', 'rock', 'scissors']
    return classes[np.argmax(pred)]
