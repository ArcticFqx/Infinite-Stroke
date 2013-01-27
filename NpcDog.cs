using UnityEngine;
using System.Collections;

public class NpcDog : MonoBehaviour {

    GameObject player;
    private float speed;
    private Vector3 moveVector = Vector3.zero;
    private Vector3 dogPosition;
    private float stamina;
    CharacterController dog;

	// Use this for initialization
	void Start () 
    {
        speed = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        dog = transform.parent.GetComponent<CharacterController>();
        moveVector.y = -10;
        stamina = 8;
	}
	
	// Update is called once per frame
    void Update()
    {
        dog.transform.position =  new Vector3(dog.transform.position.x, dog.transform.position.y, -1.0f);

        float distance = player.transform.position.x - transform.position.x;
        if (distance > 0)
            moveVector.x = Time.deltaTime * (distance*1.5f + 2) * (stamina > 5 ? stamina/5 : 1);
        else
            moveVector.x = 0;

        stamina -= Time.deltaTime;
        dog.Move(moveVector);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerTrigger")
        {
            other.GetComponent<Transform>().parent.GetComponent<PlayerControl>().health -= 5;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerTrigger")
        {
            other.GetComponent<Transform>().parent.GetComponent<PlayerControl>().health -= Time.deltaTime*5;
        }
    }
}
