using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerScript : MonoBehaviour
{
    public sceneManagerScript sceneScript;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    // Similar to our tree script, we want to make sure that when we collide with a flower that it will disappear
    // We also want to increase the flowerCount so we call the addFlower() method
    // We do this by comparing the tag and if it is the player it will disappear
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sceneScript.addFlower();
            gameObject.SetActive(false);
        }
    }
}
