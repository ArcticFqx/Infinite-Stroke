using UnityEngine;
using System.Collections;

public class ScoreLabel : MonoBehaviour {
    UILabel label;
    PlayerControl player;
	// Use this for initialization
	void Start () {
        label = GetComponent<UILabel>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        label.text = "Score: " + 0;
	}
	
	// Update is called once per frame
	void Update () {
        label.text = "Score: " + player.score.GetScore();
	}
}
