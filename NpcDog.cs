using UnityEngine;
using System.Collections;

public class NpcDog : MonoBehaviour {

    GameObject player;
    private float speed;
    private float jump;
    private Vector3 moveVector = Vector3.zero;
    private Vector3 playerPosition;
    CharacterController dog;

	// Use this for initialization
	void Start () {
        speed = 2;
        jump = Random.value * 3 + 1;
        player = GameObject.FindGameObjectWithTag("Player");
        dog = GetComponent<CharacterController>();
        moveVector.y = -10;
	}
	
	// Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(transform.position.x, transform.position.y, -1.0f);
        transform.position = playerPosition;
        if (jump < 0)
        {
            jump = Random.value * 3 + 1;
        }

        jump -= Time.deltaTime;
        float distance = player.transform.position.x - transform.position.x;
        if (distance > 0)
        {
            moveVector.x = Time.deltaTime * (distance/3 + 2);
        }

        dog.Move(moveVector);
	}

    void SubSpeed(float s)
    {
        speed -= s;
    }

    void OnTriggerEnter(Collider other)
    {
    }

    void OnTriggerStay(Collider other)
    {
        //if(other.tag == "Player")
            
    }
}
