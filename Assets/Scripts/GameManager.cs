using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> critterPrefabs;
    public float critterSpawnFrequency = 1f;
    public Score scoreDisplay;

    private float lastCritterSpawn = 0;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // check if it is time to spawn next critter
        float nextSpawnTime = lastCritterSpawn + critterSpawnFrequency; 
        if (Time.time >= nextSpawnTime)
        {
            // it is time to spawn critter

            // Choose a random critter
            int critterIndex = Random.Range(0, critterPrefabs.Count);
            GameObject prefabToSpawn = critterPrefabs[critterIndex];

            // spawn the critter
            GameObject spawnedCritter = Instantiate(prefabToSpawn);

            // Get access to our critter script
            Critter critterScript = spawnedCritter.GetComponent<Critter>();


            // Tell the critter script the score object
            critterScript.scoreDisplay = scoreDisplay;
            critterScript.scoreDisplay = scoreDisplay;


            // Update the most recent critter spawn time to now
            lastCritterSpawn = Time.time;
        }
	}
}
