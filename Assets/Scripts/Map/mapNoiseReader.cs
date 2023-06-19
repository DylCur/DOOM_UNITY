using UnityEngine;

public class mapNoiseReader : MonoBehaviour
{
    public Texture2D image;

    void Start()
    {
        ReadImageColors();
    }

    void ReadImageColors()
    {
        // Get the width and height of the image
        int width = image.width;
        int height = image.height;

        // Loop through each pixel of the image
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Get the color of the current pixel
                Color pixelColor = image.GetPixel(x, y);

                // Print the color information
                Debug.Log("Pixel at (" + x + ", " + y + ") has color: " + pixelColor);
            }
        }
    }
}
