using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    
    mapNoiseReader mapNoise;
    public int roomSize = 10;

    public Color[] roomColours = {
    
        new Color (106, 190, 48),
        new Color (162, 182, 0), 
        new Color (119, 134, 0),
        new Color (84, 95, 0),
        new Color (35, 40, 0)

    
    };

    public GameObject[] rooms;
    public GameObject[] guns;
        
 

    public Texture2D image;
    public Color[] pixelColours = new Color[256];
    public int[] widthHeight = new int[2];

    
    


    // Start is called before the first frame update
    void Start()
    {
        mapNoise = GetComponent<mapNoiseReader>();

        ReadImage();

    }

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

                if(pixelColours[x] == roomColours[0]){ // Dirt
                    Instantiate(rooms[0], new Vector3(x * roomSize, 0, y * roomSize), Quaternion.identity);
                }

                else if(pixelColours[x] == roomColours[1]){ // Basic Wall
                    
                    int j = Random.Range(1, 10);
                    
                    if(j > 1){
                        Instantiate(rooms[7], new Vector3(x * roomSize, 0, y * roomSize), Quaternion.identity);

                    }

                    else{
                        Instantiate(rooms[1], new Vector3(x * roomSize, 0, y * roomSize), Quaternion.identity);
                    }
                }

                else if(pixelColours[x] == roomColours[2]){ // Floor With Ceiling
                    Instantiate(rooms[3], new Vector3(x * roomSize, 0, y * roomSize), Quaternion.identity);
                    Instantiate(rooms[2], new Vector3(x * roomSize, 14, y * roomSize), Quaternion.identity);
                }

                else if(pixelColours[x] == roomColours[3]){ // Black
                    Instantiate(rooms[4], new Vector3(x * roomSize, 0, y * roomSize), Quaternion.identity);
                }

                else if(pixelColours[x] == roomColours[4]){ // Empty Space
                    continue;
                }

                else if(pixelColours[x] == roomColours[5]){ // Wall 2
                    Instantiate(rooms[5], new Vector3(x * roomSize, 0, y * roomSize), Quaternion.identity);
                }

                

                // Guns

                else if(pixelColours[x] == roomColours[6]){ // Pistol
                    Instantiate(rooms[3], new Vector3(x * roomSize, 0, y * roomSize), Quaternion.identity);
                    Instantiate(rooms[2], new Vector3(x * roomSize, 14, y * roomSize), Quaternion.identity);    
                    Instantiate(guns[0], new Vector3(x * roomSize, 1.5f, y * roomSize), Quaternion.identity);
                
                }

                else if(pixelColours[x] == roomColours[7]){ // Shotgun
                    Instantiate(rooms[3], new Vector3(x * roomSize, 0, y * roomSize), Quaternion.identity);
                    Instantiate(rooms[2], new Vector3(x * roomSize, 14, y * roomSize), Quaternion.identity);    
                    Instantiate(guns[1], new Vector3(x * roomSize, 1.5f, y * roomSize), Quaternion.identity);
                
                }

                else if(pixelColours[x] == roomColours[8]){ // Door
                    Instantiate(rooms[3], new Vector3(x * roomSize, 0, y * roomSize), Quaternion.identity);
                    Instantiate(rooms[2], new Vector3(x * roomSize, 14, y * roomSize), Quaternion.identity);

                    Instantiate(rooms[8], new Vector3(x * roomSize, 5, y * roomSize), Quaternion.identity);
                }
                
                else if(pixelColours[x] == roomColours[9]){ // Door Rotate
                    Instantiate(rooms[3], new Vector3(x * roomSize, 0, y * roomSize), Quaternion.identity);
                    Instantiate(rooms[2], new Vector3(x * roomSize, 14, y * roomSize), Quaternion.identity);

                    Instantiate(rooms[8], new Vector3(x * roomSize, 5, y * roomSize), Quaternion.Euler(0, 90, 0));
                }

                // This is for if the colour is invalid : This should never happen in the game (Debug Only)!!!!!!

                else{
                    print("Invalid Colour");
                    continue;
                }

            }
        }
    }

    void print(string i){
        Debug.Log(i);
    }

   
}
