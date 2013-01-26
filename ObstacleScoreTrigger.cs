using UnityEngine;
using System.Collections;

public class ObstacleScoreTrigger : MonoBehaviour {

    public int ScoreValue = 1000;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerControl>().AddScore(5);
            print("Score added");
        }
    }
    void DisableTrigge()
    {
        this.collider.isTrigger = false;
    }
}
