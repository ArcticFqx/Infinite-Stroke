using UnityEngine;
using System.Collections;

public class ObstacleScoreTrigger : MonoBehaviour {

    public int ScoreValue = 1000;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Score score = Camera.mainCamera.GetComponent<Score>();
            score.IncreaseScore(ScoreValue);
        }
    }
}
