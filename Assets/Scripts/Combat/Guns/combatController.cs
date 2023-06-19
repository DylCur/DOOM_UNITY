using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatController : MonoBehaviour
{

    [Header("Guns")]
    
    // Guns are formatted [name, damage, fire rate (Animation Time), Range]
    public string[] pistolStats = {"pistol", "50", "1", "10"};
    public string[] shotgunStats = {"shotgun", "50", "1", "10"};
    public string[] rocketStats = {"rocket", "400", "1", "99999"};


    public string[] inventory = {"n", "n"};
    public int ammo;
    public float speed = 50f;


    public string currentlySelectedGun = null;
    public bool canShoot = true;
    public GameObject cam;

    [Header("Keycodes")]

    public KeyCode oneKey = KeyCode.Alpha1;
    public KeyCode twoKey = KeyCode.Alpha2, 
        threeKey = KeyCode.Alpha3,
        fourKey = KeyCode.Alpha4, 
        fiveKey = KeyCode.Alpha5,
        sixKey = KeyCode.Alpha6, 
        sevenKey = KeyCode.Alpha7,
        shootKey = KeyCode.Mouse0;


    [Header("Rocket Items")]

    public GameObject explosionObj;
    [HideInInspector] public Animator explosionAnim;




    

    [Header("Shooting Parameters")]

    public LayerMask enemyLayer;
    public LayerMask playerMask;
    public float radius = 5f;


    [Header("Holders")]

    public CharacterController charControl;
    playerController playerControl;
    public GameObject animControlHolder;
    public Animator anim;
    gunVisuals gunVis;
    animationController animControl;
    
    bool wait = false;

    

    




    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireSphere(transform.position, radius);
    // }
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<playerController>();
        animControl = animControlHolder.GetComponent<animationController>();
        gunVis = GetComponent<gunVisuals>();
        print(inventory.Length);
     
    }

    // Update is called once per frame
    void Update()
    {
        #region Bad_Should_FIX
        if (Input.GetKeyDown(oneKey)) 
        {
            inventoryCheck(1);
        }

        if (Input.GetKeyDown(twoKey))
        {
            inventoryCheck(2);
        }

        if (Input.GetKeyDown(threeKey))
        {
            inventoryCheck(3);
        }

        if (Input.GetKeyDown(fourKey))
        {
            inventoryCheck(4);
        }

        if (Input.GetKeyDown(fiveKey))
        {
            inventoryCheck(5);
        }

        if (Input.GetKeyDown(sixKey))
        {
            inventoryCheck(6);
        }

        if (Input.GetKeyDown(sevenKey))
        {
            inventoryCheck(7);
        }
        #endregion

        if (Input.GetKeyDown(shootKey) && canShoot){
            shoot();
        }
    }

    void inventoryCheck(int keyNumber)
    {
        // I subtract one from keynumber so if you press 1 for example, it will get the first item in the array as 1 - 1 = 0

        print("Inv Check");

        for(int i = 0; i < inventory.Length; i++)
        {
            if (keyNumber - 1 == i)
            {
                if (inventory[keyNumber - 1] != "n")
                {
                    print("Gun in inv");
                    currentlySelectedGun = inventory[keyNumber - 1];
                    gunVis.ChangeSprite(currentlySelectedGun.ToLower());

                    if(currentlySelectedGun == "shotgun"){
                        anim.SetBool("shotgun", true);
                        anim.SetBool("pistol", false);
                        anim.SetBool("rocket", false);

                    }

                    if(currentlySelectedGun == "pistol"){
                        anim.SetBool("shotgun", false);
                        anim.SetBool("pistol", true);
                        anim.SetBool("rocket", false);
                    }

                    if(currentlySelectedGun == "rocket"){
                        anim.SetBool("shotgun", false);
                        anim.SetBool("pistol", false);
                        anim.SetBool("rocket", true);
                    }

                    

                    
                }
            }
        }
        
    }

    void shoot()
    {
        print("Has Shot");
        RaycastHit hit; // Declare the 'hit' variable of type RaycastHit

        if (currentlySelectedGun == "shotgun")
        {
            print("Shotgun");
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, float.Parse(shotgunStats[3]), enemyLayer)) // float.Parse Converts to a string
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                print("Ray Drawn");
            }

            anim.SetBool("shooting", true);

            StartCoroutine(waitForShot("shotgun"));
        }

        if (currentlySelectedGun == "pistol")
        {
            print("Pistol");
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, float.Parse(pistolStats[3]), enemyLayer)) // float.Parse Converts to a string
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                print("Ray Drawn");
            }

            anim.SetBool("shooting", true);

            StartCoroutine(waitForShot("pistol"));


        }

        if (currentlySelectedGun == "rocket")
        {
            print("Rocket");
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, float.Parse(rocketStats[3]), ~playerMask)) // float.Parse Converts to a string
            {
                CreateExplosion(hit, 5f);
            }

            anim.SetBool("shooting", true);

            StartCoroutine(waitForShot("rocket"));


        }
    }

    
    
    void CreateExplosion(RaycastHit hit, float radius){
        if(!wait){
            GameObject explode = Instantiate(explosionObj, hit.point, Quaternion.identity);
            explosionAnim = explode.GetComponent<Animator>();

            explosionAnim.SetBool("explode", true);
            wait = true;
            StartCoroutine(WaitForRocket(explode));


        }   
       

    }
    
    void print(string item){
        Debug.Log(item);
    }
    
    


    public IEnumerator waitForShot(string gun){
        if(gun == "shotgun"){
            yield return new WaitForSeconds(float.Parse(shotgunStats[2]));
            anim.SetBool("shooting", false);

        }

        if(gun == "pistol"){
            yield return new WaitForSeconds(float.Parse(pistolStats[2]));
            anim.SetBool("shooting", false);

        }

        if(gun == "rocket"){
            yield return new WaitForSeconds(float.Parse(rocketStats[2]));
            anim.SetBool("shooting", false);
        }

        anim.SetBool("shooting", false);
    }

    public IEnumerator WaitForRocket(GameObject explode){
        yield return new WaitForSeconds(float.Parse(rocketStats[2]));
        explosionAnim.SetBool("explode", false);
        Destroy(explode);
        wait = false;


    }


    
        

    
}
