using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool moving;
    public GameObject Player;
    public float speed = 2.0f;
    
    public TopDownScript playerScript;
    
    void Start()
    {
        // Need the enemy to locate the player immediately
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // While the game is not over
        if (playerScript.gameIsOver == false)
        {
            // Keep moving while game is not over
            moving = true;
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
        
    }

    // Similar to tree and flower script, when the enemy collides with the player
    // Need to decrease health from the player and we will move the enemy back small distance away from the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript.playerGetsHurt();
            transform.position =
                Vector2.MoveTowards(transform.position, Player.transform.position, -150 * Time.deltaTime);
        }
    }
}
