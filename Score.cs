using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{


    private int score = 0;
    private int multiplier = 9;
    private HsHelper hs;


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

    public void SaveScore()
    {
        hs.ReceieveScore(score);
    }

    void Start()
    {
        hs = GameObject.FindGameObjectWithTag("scorekeeper").GetComponent<HsHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Score: " + score);
        }

    }
}