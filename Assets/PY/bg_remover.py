from PIL import Image

def replace_color_with_transparency(image_path, target_color):
    # Load the image
    image = Image.open(image_path).convert("RGBA")
    pixels = image.load()

    # Iterate over each pixel
    for y in range(image.height):
        for x in range(image.width):
            r, g, b, a = pixels[x, y]
            # Check if the pixel color matches the target color
            if (r, g, b) == target_color:
                # Set the pixel's alpha channel to 0 (fully transparent)
                pixels[x, y] = (r, g, b, 0)

    # Save the modified image
    image.save("modified_image.png")

# Example usage
replace_color_with_transparency("C://Users//dylan_ujugo02//Desktop//DOOM_UNITY//Assets//PY//a.png", (255, 0, 110))  # Replace red pixels with transparency
