using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeScript : MonoBehaviour
{   
    // Setting tree health
    public int health = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Need to update when the tree/log is destroyed so that they don't show anymore on the screen
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
    // Method to check if collision with our axe connects with the tree/log
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("axe"))
        {
            health--;
        }
    }
}
