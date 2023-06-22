using UnityEngine;

public class mapNoiseReader : MonoBehaviour
{
    public Texture2D image;
    public Color[] pixelColours = new Color[256];
    public int[] widthHeight = new int[2];

    public void ReadImage()
    {
        // Get the width and height of the image
        int width = image.width;
        int height = image.height;
        widthHeight[0] = width;
        widthHeight[1] = height;

        // Loop through each pixel of the image
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Get the color of the current pixel
                pixelColours[x] = image.GetPixel(x, y);

            }
        }
    }
}
