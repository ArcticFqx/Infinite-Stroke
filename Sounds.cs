using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

    public AudioClip[] footstep;
    public AudioClip[] dog;
    public AudioClip[] grunt;
    public AudioClip[] heart;
    public AudioClip[] impact;
    public AudioClip flatline;

    private AudioSource sourceHeart;
    private AudioSource sourceImpact;
    private AudioSource sourceGrunt;
    private AudioSource sourceFootstep;
    private AudioSource sourceFlat;


    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        sourceHeart = sources[0];
        sourceImpact = sources[1];
        sourceGrunt = sources[2];
        sourceFootstep = sources[3];
        sourceFlat = sources[4];
    }

    public void PlayFootStep()
    {
        sourceFootstep.clip = footstep[Random.Range(0, footstep.Length)];
        sourceFootstep.Play();
    }

    public void PlayHeart()
    {
        sourceHeart.clip = heart[Random.Range(0, heart.Length)];
        sourceHeart.Play();
    }

    public void PlayImpact()
    {
        sourceImpact.clip = impact[Random.Range(0, impact.Length)];
        sourceImpact.Play();
    }
    public void PlayGrunt()
    {
        sourceGrunt.clip = grunt[Random.Range(0, grunt.Length)];
        sourceGrunt.Play();
    }
    public void PlayFlat()
    {
        sourceFlat.clip = flatline;
        sourceFlat.Play();
    }
}
