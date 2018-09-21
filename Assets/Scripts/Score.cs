using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    // public variables are visible throughout Unity
    public TextMesh displayText;

    // private variables cannot be touched by other scripts
    private int currentValue = 0;

	// Update both the data and visual display values of score
    public void ChangeValue(int _toChange)
    {
        currentValue = currentValue + _toChange;
        displayText.text = currentValue.ToString();
    }

}
