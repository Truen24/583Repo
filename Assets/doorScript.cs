using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public sceneManagerScript sceneMS;
    public bool doorUp;
    public TopDownScript playerScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (doorUp == true)
            {
                playerScript.resetPlayerPosition();
                sceneMS.currentRoomNumber--;
            }
            if (doorUp == false)
            {
                playerScript.resetPlayerPosition();
                sceneMS.currentRoomNumber++;
            }
        }
    }
}
