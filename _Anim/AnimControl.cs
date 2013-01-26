using UnityEngine;
using System.Collections;

public class AnimControl : MonoBehaviour {

    private Animator anim;
    private AnimationState astate;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void PlayRunAnimation(float speed)
    {
        animation.Play("Run");
        animation["Run"].speed = speed;
    }

    public void PlayJumpAnimation()
    {
        animation.Play("Jump");
    }
}
