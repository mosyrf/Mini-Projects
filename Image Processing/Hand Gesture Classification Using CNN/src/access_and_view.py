import matplotlib.pyplot as plt
import matplotlib.image as mpimg
import os
import random
import math

def view_samples(data_dir: str, classes: list, rows: int = 2, cols: int = 3):
    n = rows * cols
    fig, axes = plt.subplots(rows, cols, figsize=(3*cols, 3*rows))

    # kalau cuma 1 baris/kolom, axes bukan 2D → kita flatten
    axes = axes.flatten()

    for i in range(n):
        cls = random.choice(classes)
        img_name = random.choice(os.listdir(os.path.join(data_dir, cls)))
        img_path = os.path.join(data_dir, cls, img_name)
        img = mpimg.imread(img_path)

        axes[i].imshow(img)
        axes[i].set_title(cls)
        axes[i].axis("off")

    plt.tight_layout()
    plt.show()

if __name__ == "__main__":
    DATA_DIR = "data/processed"
    classes = ["paper", "rock", "scissors"]
    view_samples(DATA_DIR, classes, rows=3, cols=3)  # 🔥 grid 3x3
