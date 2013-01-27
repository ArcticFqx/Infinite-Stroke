using UnityEngine;
using System.Collections;

public class PlayAgainButton : MonoBehaviour {


	// Use this for initialization
    void OnClick()
    {
        GameObject scorethingy = GameObject.FindGameObjectWithTag("scorekeeper");
        Destroy(scorethingy);

        Application.LoadLevel(0);
    }
}
