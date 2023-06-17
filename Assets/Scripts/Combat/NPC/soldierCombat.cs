using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierCombat : MonoBehaviour
{
    [Header("Attacking Parameters")]
    public int soldierDamage;

    [Header("Pathfinding Parameters")]
    public Transform playerPosition;
    public int speed;
    public float avoidanceRadius = 2f;
    public float desiredDistance = 1f; // Added desiredDistance parameter

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerPosition != null)
        {
            Vector3 directionToplayerPosition = playerPosition.position - transform.position;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, directionToplayerPosition, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    // playerPosition is within line of sight, move towards the playerPosition
                    float currentDistance = Vector3.Distance(transform.position, playerPosition.position);
                    
                    if (currentDistance > desiredDistance)
                    {
                        transform.LookAt(playerPosition);
                        transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    }
                }
                else if (hit.distance <= avoidanceRadius)
                {
                    // There's an obstacle, avoid it
                    Vector3 avoidanceDirection = Vector3.Cross(Vector3.up, directionToplayerPosition).normalized;
                    transform.Translate(avoidanceDirection * speed * Time.deltaTime);
                }
            }
        }
    }
}
