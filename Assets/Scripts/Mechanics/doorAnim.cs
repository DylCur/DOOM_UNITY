using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAnim : MonoBehaviour
{


    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        print("Collided!!!!");
        if(other.tag == "Player"){
            anim.SetBool("open", true);
        }       
    }

    void OnTriggerExit(Collider other)
    {
        print("Exited!");
        anim.SetBool("open", false);
    }

    void print(string i){
        Debug.Log(i);
    }
}
