using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    bool anim;
    public Animator animator;  
    combatController combatControl;
    public GameObject combatControlHolder;

    void Start()
    {
        anim = true;
        combatControl = combatControlHolder.GetComponent<combatController>(); 
    }

    public void GunAnim(string gun){



        if(anim){
            if(gun == "shotgun"){
                animator.SetBool("shotgun", true);
                animator.SetBool("pistol", false);
                animator.SetBool("rocket", false);
                


            }

            if(gun == "pistol"){
                animator.SetBool("pistol", true);
                animator.SetBool("shotgun", false);
                animator.SetBool("rocket", false);
            }

            StartCoroutine(waitForAnim(gun));
        }
       
        
    }


    public IEnumerator waitForAnim(string gun){
        anim = false;
        if(gun == "shotgun"){
            yield return new WaitForSeconds(float.Parse(combatControl.shotgunStats[2]));
            animator.SetBool("shotgun", false);

        }

        if(gun == "pistol"){
            yield return new WaitForSeconds(float.Parse(combatControl.shotgunStats[2]));
            animator.SetBool("pistol", false);
        }
        anim = true;
    }
}

