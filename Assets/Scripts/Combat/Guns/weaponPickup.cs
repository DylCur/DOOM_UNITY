using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour
{

    public string playerTag = "Player";

    [Header("Gun Tags")]
    public string pistolTag = "Pistol";
    public string shotgunTag = "Shotgun"; 

    public string[] gunTags = new string[2];
    
    [Space(50)]

    combatController combatControl;
    public GameObject combatControlHolder; 



    // Start is called before the first frame update
    void Start()
    {
        combatControl = combatControlHolder.GetComponent<combatController>();
        gunTags[0] = pistolTag;
        gunTags[1] = shotgunTag;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger");
        if(other.tag == playerTag){
            for(int i = 0; i < gunTags.Length; i++){
                if(gameObject.tag == gunTags[i]){
                    combatControl.inventory[i] = gameObject.tag.ToLower(); // I thing gameObject.tag.ToLower() is faster that gunTags[i].ToLower()
                    Destroy(gameObject);
                }
            }
        }    
    }

    void print(string i){
        Debug.Log(i);
    }
}
