using UnityEngine;

public class renderDistance : MonoBehaviour
{
    public float renderDist = 100f; // Set the desired render distance here

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        foreach (var renderer in FindObjectsOfType<Renderer>())
        {
            if (Vector3.Distance(renderer.transform.position, mainCamera.transform.position) <= renderDist)
            {
                renderer.enabled = true;
            }
            else
            {
                renderer.enabled = false;
            }
        }
    }
}
