import matplotlib.pyplot as plt
import matplotlib.image as mpimg
import os
import random

def view_samples(data_dir: str, classes: list, n: int = 5):
    plt.figure(figsize=(12, 6))
    for i in range(n):
        cls = random.choice(classes)
        img_name = random.choice(os.listdir(os.path.join(data_dir, cls)))
        img_path = os.path.join(data_dir, cls, img_name)
        img = mpimg.imread(img_path)
        plt.subplot(1, n, i + 1)
        plt.imshow(img)
        plt.title(cls)
        plt.axis("off")
    plt.show()
