using UnityEngine;
using System.Collections;

public class hshelper : MonoBehaviour {

	// Use this for initialization
    private Score score;

    void Start () 
    {
        DontDestroyOnLoad(transform.gameObject);
        score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
	}
	
	// Update is called once per frame

    public int GetScore()
    {
        return score.GetScore();
    }

	void Update () {
	
	}
}
