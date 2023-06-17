using System.Runtime.InteropServices;
using System.IO.Pipes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour
{

    public string pistolTag = "Pistol";
    public string shotgunTag = "Shotgun";

    public string[] possibleTags = new string[2];

    combatController combatControl;



    // Start is called before the first frame update
    void Start()
    {


        combatControl = GetComponent<combatController>();


        // Init the possibleTags array
        possibleTags[0] = pistolTag;
        possibleTags[1] = shotgunTag;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        print("Entered");

        // I dont use a foreach loop as i need the index (I tried to use it initially :| )
        for(int i = 0; i < possibleTags.Length; i++){                                       // Cycles through possible tags
            if(other.tag == possibleTags[i]){                                               // If the tag is in the possible tags array
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
