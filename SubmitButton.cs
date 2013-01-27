using UnityEngine;
using System.Collections;

public class SubmitButton : MonoBehaviour {

    private Highscore hs;

	// Use this for initialization
    void OnClick()
    {
        hs = GameObject.FindGameObjectWithTag("highscore").GetComponent<Highscore>();
        hs.Submit();
    }
}
