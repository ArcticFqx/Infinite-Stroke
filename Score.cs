using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {


    private int score = 0;
    private int multiplier = 1;


    public void IncreaseScore(int points)
    {
        score += points * multiplier;
    }

    public void DecreaseScore(int points)
    {
        score -= points;
    }

    public void IncreaseMultiplier(int value)
    {
        multiplier += value;
    }

    public void DecreaseMultiplier(int value)
    {
        multiplier -= value;
    }

    public void SetMultiplier(int value)
    {
        multiplier = value;
    }

    public int GetScore()
    {
        return score;
    }
    
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Score: " + score);
        }

	}
}
