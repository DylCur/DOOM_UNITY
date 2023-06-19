using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunVisuals : MonoBehaviour
{

    [Header("Gun Sprites")]

    public Sprite pistol;
    public Sprite shotgun;
    public Image gunImage;

    Color visable = new Color(255, 255, 255, 255);
    Color invisable = new Color(255, 255, 255, 0);

    

    combatController combatControl;
    

    

    // Start is called before the first frame update
    void Start()
    {
        combatControl = GetComponent<combatController>();
    }


    public void ChangeSprite(string sprite){

        if(sprite == "n"){
            gunImage.color = invisable;
        }
        
        else{
            gunImage.color = visable;
        }
    }
}
