using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critter : MonoBehaviour {

    public Vector2 lowerRange;
    public Vector2 upperRange;
    public Score scoreDisplay;
    public Timer timer;
    public int pointValue = 1; // how many points is the critter worth

    private Vector2 direction; // What direction is the critter traveling in

	// Use this for initialization
	void Start () {

        transform.position = new Vector3 (Random.Range(lowerRange.x, upperRange.x), Random.Range(lowerRange.y, upperRange.y), 0);

        // Pick a random direction for this critter
        direction.x = Random.Range(-1.0f, 1.0f);
        direction.y = Random.Range(-1.0f, 1.0f);
        direction = direction.normalized;

        // Rotate critten in direction of movement
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);


	} // End of void Start()
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.up * Time.deltaTime);

        if (timer.IsTimerRunning() == false)
        {
            Destroy(gameObject);
        }
	} // End of void Update()

    // unity calls this when game object is clicked
    void OnMouseDown()
    {
        scoreDisplay.ChangeValue(pointValue);
        Destroy(gameObject);
    } // End of void OnMouseDown()

} // End of class
