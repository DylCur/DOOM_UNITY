using System.Runtime.InteropServices;
using System.IO.Pipes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour
{

    public string pistolTag = "Pistol";
    public string shotgunTag = "Shotgun";
    public string rocketTag = "rocket";

    public string[] possibleTags = new string[3];

    combatController combatControl;
    gunVisuals gunVis;
    animationController animControl;
    public GameObject animControlHolder;
    





    // Start is called before the first frame update
    void Start()
    {
        animControl = animControlHolder.GetComponent<animationController>();
        gunVis = GetComponent<gunVisuals>();
        combatControl = GetComponent<combatController>();


        // Init the possibleTags array
        possibleTags[0] = pistolTag;
        possibleTags[1] = shotgunTag;
        possibleTags[2] = rocketTag;

        gunVis.ChangeSprite("n");

    }

    void OnTriggerEnter(Collider other)
    {
        print("Entered");   

        // I dont use a foreach loop as i need the index (I tried to use it initially :| )
        for(int i = 0; i < possibleTags.Length; i++){                                       // Cycles through possible tags
            if(other.tag.ToLower() == possibleTags[i].ToLower()){                                     // If the tag is in the possible tags array
                print("Is gun");
                combatControl.inventory[i] = possibleTags[i].ToLower();                     // It will add the item to the inventory
                combatControl.ammo += 12;                                                   // Increase the ammo (This means that if they dont have the gun they will be able to use it immediately)
                Destroy(other.gameObject);                                                  // Gets rid of the gun to pickup (This means the player cannot pick it up again)
            }
        }
    }

    void print(string i){
        Debug.Log(i);   
    }
}
