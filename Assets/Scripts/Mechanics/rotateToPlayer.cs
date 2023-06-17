using UnityEngine;

public class rotateToPlayer : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        // Rotate towards the player's position
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
    }
}
