using UnityEngine;
using System.Collections;

public class PumpIndicator : MonoBehaviour {

    PlayerControl player;
    UISlider heartBar;

    void Start()
    {
        heartBar = GetComponent<UISlider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    public void UpdateSlider(float progress)
    {
        heartBar.sliderValue = progress;
        Debug.Log(heartBar.sliderValue);
    }

    void Update()
    {
        UpdateSlider(player.rate);
    }
}
