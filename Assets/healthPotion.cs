using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPickup : MonoBehaviour
{
    // Creating reference
    public TopDownScript playerScript;
    // Creating Sound
    [SerializeField] private AudioClip potionSound;
    
    // Health Potion will increase the players health by 1
    public int healthIncreaseAmount = 1;
    
    // Similar to Tree and Flower Script we want the potion to disappear when the playerw walks over the potion
    // We also want to make sure we are increasing the players health so we add that as well
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Playing sound when potion is picked up and incrementing the health
            SoundManager.instance.PlaySound(potionSound);
            playerScript.health += healthIncreaseAmount;
            gameObject.SetActive(false);
        }
    }
}




