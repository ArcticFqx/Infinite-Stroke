using UnityEngine;
using System.Collections;

public class NpcDog : MonoBehaviour {

    GameObject player;
    private float speed;
    private float jump;
	// Use this for initialization
	void Start () {
        speed = 2;
        jump = Random.value * 3 + 1;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (jump < 0)
        {
            jump = Random.value * 3 + 1;
        }

        jump -= Time.deltaTime;
        if (true)
        {
            float add = Time.deltaTime * (player.transform.position.x - transform.position.x) / 15;
            //print("Dog: " + add);
            speed += add;
        }

        speed = speed > 0 ? speed : 0;

        transform.Translate(new Vector3(-speed, 0,0) * Time.deltaTime);
	}

    void SubSpeed(float s)
    {
        speed -= s;
    }

    void OnTriggerEnter(Collider other)
    {
        SubSpeed(speed/2);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
            SubSpeed(speed*Time.deltaTime*3);
    }
}
