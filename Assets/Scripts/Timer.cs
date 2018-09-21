using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    // Display visual timer
   public TextMesh displayText;

    // Starting time for timer
    public float timerDuration;

    // Current seconds remaining on timer
    private float timeRemaining = 0;


	// Use this for initialization
	void Start () {
        
	}// End of void Start()
	
	// Update is called once per frame
	void Update () {
		
        // Only process the timer if it is running
        if (IsTimerRunning())
        {
            // Timer is running so progress

            // Updated the time remaining in this frame
            timeRemaining = timeRemaining - Time.deltaTime;

            // Check if we have run out of time
            if (timeRemaining <= 0)
            {
                StopTimer();
            }

            // Update the visual display
            displayText.text = Mathf.CeilToInt(timeRemaining).ToString();

        }

    } // End of void Update()

    // Starts the timer countdown
    public void StartTimer()
    {
        timeRemaining = timerDuration;
        displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
    } // End of void StartTimer()


    // Stop the timer countdown
    public void StopTimer()
    {
        timeRemaining = 0;
        displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
    } // End of void StopTimer()


    // Check if time is still running
    public bool IsTimerRunning()
    {
        if (timeRemaining <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    } // End of public bool()
} // End of class
