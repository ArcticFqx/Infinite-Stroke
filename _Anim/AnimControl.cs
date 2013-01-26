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
        animation.CrossFade("Run", 0.2f);
        animation["Run"].speed = speed;
    }

    public void PlaySlideAnimation()
    {
        animation.wrapMode = WrapMode.Once; 
        animation.CrossFade("Death", 0.2f);
    }
}
