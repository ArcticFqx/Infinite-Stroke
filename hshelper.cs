using UnityEngine;
using System.Collections;

public class HsHelper : MonoBehaviour {

	// Use this for initialization
    private Score score;
    private int Score;

    void Start () 
    {
        DontDestroyOnLoad(transform.gameObject);
        score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
	}

    public void ReceieveScore(int playerScore)
    {
        Score = playerScore;
    }
	
	// Update is called once per frame

    public int GetScore()
    {
        return score.GetScore();
    }
}
