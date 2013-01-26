using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {


    private bool first;

    private float speed;
    public float speedAnimRatio = 3.5f;
    public float maxSpeed;
    private bool isJumping = false;
    private bool isSliding = false;

    private float gravity;

    private float jumpSpeed;
    private float health;

    private bool heart;
    private float rate;
    private float rateMul;

    private Score score;

    private Vector3 moveVector = Vector3.zero;
    private Vector3 playerPosition;
    private AnimControl anim;

    private CharacterController controller;
	// Use this for initialization
	void Start () 
    {   
        gravity = 20;
        jumpSpeed = 10.0f;
        heart = false;
        speed = 6;
        health = 100;
        rate = 0;
        rateMul = 1;
        controller = GetComponent<CharacterController>();
        anim = GameObject.FindGameObjectWithTag("Fatty").GetComponent<AnimControl>();
        score = GetComponent<Score>();
        maxSpeed = 8;
        isJumping = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(transform.position.x, transform.position.y, -1.0f);
        transform.position = playerPosition;
        Beat();
        MoveCharacter();
	}

    void MoveCharacter()
    {
        if (controller.isGrounded)
        {
            if( !isSliding && Input.GetKey(KeyCode.DownArrow)  )
                anim.PlaySlideAnimation();
            else if(!Input.GetKey(KeyCode.DownArrow))
                anim.PlayRunAnimation(speed / speedAnimRatio);

            moveVector = new Vector3(speed, 0.0f, 0.0f);
       
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveVector.y = jumpSpeed;
                isJumping = true;
            }
            isSliding = Input.GetKey(KeyCode.DownArrow);
        }
        if (!controller.isGrounded && isJumping)
        {
            isJumping = false;
        }

        moveVector.y -= gravity * Time.deltaTime;
        controller.Move(moveVector * Time.deltaTime);


    }

    void Beat()
    {
        float keyHeartRaw = Input.GetAxisRaw("Heart");
        bool keyHeart = Input.GetButtonDown("Heart");
        rate -= Time.deltaTime * rateMul;
        float beat = 1 - Mathf.Abs(rate);
        float acc = 2;

        if (keyHeart)
        {
            float timing = Mathf.Abs(rate * acc);
            if (first)
            {
                speed += 4 / (speed + 4);
                heart = keyHeartRaw > 0;
                rate = heart ? 0.45f : 0.25f;
                score.IncreaseScore((int)timing * 5);
                first = false;
            }
            else if (!heart && keyHeartRaw > 0)
            {
                speed += (maxSpeed - 2) / (speed + 2) - timing;
                heart = true;
                SetRateTime();
                print("Beat: " + beat);
                score.IncreaseScore((int)timing*5);
            }
            else if (heart && keyHeartRaw < 0)
            {
                speed += (maxSpeed - 2) / (speed + 2) - timing;
                heart = false;
                SetRateTime();
                print("Beat: " + beat);
                score.IncreaseScore((int)timing * 5);
            }
            else if (keyHeartRaw != 0 && speed > 0)
            {
                speed -= 1.75f;
            }
        }
        else if (speed > 0)
        {
            speed -= Time.deltaTime * 2;
        }
        speed = speed > 2 ? speed : 2;
    }

    void SetRateTime()
    {
        rate = heart ? 0.45f/rateMul : 0.25f/rateMul;
    }

    void SubHealth(float h)
    {
        health -= h;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Dog")
            SubHealth(5);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.name == "Dog")
            SubHealth(50 * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        print("crash");
    }
}
