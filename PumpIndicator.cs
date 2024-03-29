using UnityEngine;
using System.Collections;

public class PumpIndicator : MonoBehaviour {

    PlayerControl player;
    UISlider heartBar;
    private float slidePos = 0;
    void Start()
    {
        heartBar = GetComponent<UISlider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    public void UpdateSlider(float progress)
    {
        heartBar.sliderValue = progress;
        //Debug.Log(heartBar.sliderValue);
    }

    void Update()
    {
        slidePos = player.rate / (player.heart ? 0.45f : -0.25f);
        if (!player.heart) slidePos += 1;
        UpdateSlider(slidePos);
    }
}
