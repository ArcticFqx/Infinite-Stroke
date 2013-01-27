using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

    private float secondsToHold = 2.0f;

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        secondsToHold -= 1 * Time.deltaTime;

        if (secondsToHold <= 0.0f)
        {
            Application.LoadLevel("MainMenu");
        }
	}
}
