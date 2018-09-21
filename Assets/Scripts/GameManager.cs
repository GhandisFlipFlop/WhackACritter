using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> critterPrefabs;
    public float critterSpawnFrequency = 1f;
    public Score scoreDisplay;
    public Timer timer;
    public SpriteRenderer button;

    private float lastCritterSpawn = 0;

    // Use this for initialization
	void Start () {
		
	} // End of void Start()
	
	// Update is called once per frame
	void Update () {

        // check if it is time to spawn next critter
        float nextSpawnTime = lastCritterSpawn + critterSpawnFrequency; 
        if (Time.time >= nextSpawnTime && timer.IsTimerRunning() == true)
        {
            // it is time to spawn critter

            // Choose a random critter
            int critterIndex = Random.Range(0, critterPrefabs.Count);
            GameObject prefabToSpawn = critterPrefabs[critterIndex];

            // spawn the critter
            GameObject spawnedCritter = Instantiate(prefabToSpawn);

            // Get access to our critter script
            Critter critterScript = spawnedCritter.GetComponent<Critter>();


            // Tell the critter script the score object and the timer object
            critterScript.timer = timer;
            critterScript.scoreDisplay = scoreDisplay;


            // Update the most recent critter spawn time to now
            lastCritterSpawn = Time.time;
        } // End of if

        // Update button visiblity
        if (timer.IsTimerRunning() == false)
        {
            button.enabled = true;
        }
        else  // If game is not running
        {
            button.enabled = false;
        }

	}// End of update


    // Did they click the button
    private void OnMouseDown()
    {
        // only respawn if game is not running
        if (timer.IsTimerRunning() == false)
        {
            timer.StartTimer();
            scoreDisplay.ResetScore();
        }
    } // End of void OnMouseDown
} // End of class
