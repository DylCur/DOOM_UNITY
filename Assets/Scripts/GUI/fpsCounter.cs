using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fpsCounter : MonoBehaviour
{
    private float deltaTime = 0.0f;
    bool updateFPS = true;
    public TMP_Text textItem;

    private void Update()
    {
        // Calculate the time taken to render the frame
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        Debug.Log(fps);

        if(updateFPS){
            StartCoroutine(UpdateTheFPS(fps));
        }
        


    }


    IEnumerator UpdateTheFPS(float fps){
        updateFPS = false;
        textItem.text = $"FPS: {Mathf.RoundToInt(fps)}";
        yield return new WaitForSeconds(0.1f);
        updateFPS = true;
    }

    
}
