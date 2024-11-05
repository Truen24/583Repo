using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownScript : MonoBehaviour
{
    // Start is called before the first frame update
    // Initializing Variables
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip chopSound;
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public sceneManagerScript flowerReference;

    public Animator playerAnim;
    public int health;
    public GameObject gameOverScene;
    public bool gameIsOver;
    
    void Start()
    {
        // Setting the state of the game to false because we only want it to end under certain conditions.
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver == false) // While the game is not over
        {
            moveInput.x = Input.GetAxis("Horizontal"); // Setting up movement
            moveInput.y = Input.GetAxis("Vertical");
            rb2d.velocity = moveInput.normalized * moveSpeed;

            // Check to handle the rotation of our player
            if (moveInput.x > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }else if(moveInput.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            // Handling the axe animation so that it looks like our playing is chopping down the trees/wood
            if (Input.GetKeyDown(KeyCode.Space)) // Chopping wood
            {
                SoundManager.instance.PlaySound(chopSound);
                playerAnim.Play("playerSword");
            }
        }
        
        // The check if the game should be over, checking flowerCount, the health, and totalTime
        if (flowerReference.flowerCount >= 35 || health <= 0 || flowerReference.totalTime <= 0)
        {
            gameIsOver = true;
            moveSpeed = 0;
            moveInput.Normalize();
            rb2d.velocity = moveInput * moveSpeed;
            flowerReference.timeRunning = false; // Need to turn the time off

            gameOverScene.SetActive(true); // making sure the gameOver scene is active indicating the game is over
        }

    }
    
    // Simple method to show that our player has been hit by the enemy
    public void playerGetsHurt()
    {
        health--;
        SoundManager.instance.PlaySound(hurtSound);
        playerAnim.Play("playerHurt");
    }
    
    // When a new game is started or level 2 is entered
    public void resetPlayerPosition()
    {
        transform.position = new Vector3(-2, 0, 0);
    }
    
    // Restarting the game when the button is clicked
    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }
    
    // Increasing our players HP when the potion is walked over
    public void IncreaseHealth(int hp)
    {
        health += hp;
    }

}
