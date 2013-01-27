using UnityEngine;
using System.Collections;

public class GroupScreen : MonoBehaviour {
    private float timeToWait = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeToWait -= 1 * Time.deltaTime;

        if (timeToWait <= 0.0f)
        {
            Application.LoadLevel("titleScreen");
        }
	}
}
