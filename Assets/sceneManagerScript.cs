using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class sceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    // Intializing all variables and audio clips
    [SerializeField] private AudioClip flowerSound;
    [SerializeField] private AudioClip startSound;
    public TMP_Text bestTimeText;
    public TopDownScript timerReference;
    public int currentRoomNumber;
    public int flowerCount;
    public GameObject scene0;
    public GameObject scene1;
    public float totalTime = 90f;
    public TMP_Text displayTime;
    public bool timeRunning;
    public float testingStuff = 1f;
    public float bestTime = 1000f;

    public TMP_Text flowerText;
    void Start()
    {
        // Initial variables set for flowerCount and the timer
        // Also playing a start sound
        SoundManager.instance.PlaySound(startSound);
        flowerCount = 0;
        timeRunning = true;
    }

    // Update is called once per frame
    void Update()
    {

        // Initializing our flower count so it displays correctly
        flowerText.text = flowerCount.ToString();
        // Setting the room number so our levels are correct
        if (currentRoomNumber == 0)
        {
            // if the room number is 0 that means we are on the first level
            scene0.SetActive(true);
            scene1.SetActive(false);
        }

        if (currentRoomNumber == 1)
        {
            // if the room number is 1 that means we are on the second level
            scene0.SetActive(false);
            scene1.SetActive(true);
        }
        
        if (timeRunning)
        {
            totalTime -= Time.deltaTime;  // Count down
            displayTime.text = Mathf.Max(totalTime, 0).ToString("F2");  // Display remaining time

            // Check for end conditions: all flowers collected, timer ran out, or player died
            if (flowerCount >= 35 || timerReference.health <= 0 || totalTime <= 0)
            {
                timeRunning = false;  // Stop the timer
            }
        }
    }

    // Method to add the flower count
    public void addFlower()
    {
        // Playing sound when flower count is incremented
        SoundManager.instance.PlaySound(flowerSound);
        flowerCount++;
    }
    

}
