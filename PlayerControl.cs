using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{


    private bool first;

    private float speed;
    public float speedAnimRatio = 3.5f;
    public float maxSpeed;
    private bool isJumping = false;
    private bool isSliding = false;

    private float gravity;

    private float jumpSpeed;
    public float health;
    private bool alive;
    private float damageDelay;

    public bool heart;
    public float rate;
    public float indicator;
    public float rateMul;

    public CollideEffects coEffect;

    private float startPoint;
    private float distanceRan;
    public Score score;
    private float scoreDelay = 1;

    private Vector3 moveVector = Vector3.zero;

    private float zAxis = 0.0f;
    private Vector3 playerPosition;
    private AnimControl anim;

    private CharacterController controller;
    // Use this for initialization
    void Start()
    {
        gravity = 20;
        jumpSpeed = 10.0f;
        heart = false;
        speed = 2;
        health = 100;
        rate = 0;
        indicator = 1;
        rateMul = 1;
        alive = true;
        controller = GetComponent<CharacterController>();
        anim = GameObject.FindGameObjectWithTag("Fatty").GetComponent<AnimControl>();
        score = GetComponent<Score>();
        maxSpeed = 6;
        coEffect = GetComponent<CollideEffects>();
        isJumping = false;
        damageDelay = 0;
        startPoint = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(transform.position.x, transform.position.y, -1.0f);
        transform.position = playerPosition;
        
        scoreDelay -= Time.deltaTime;
        if(scoreDelay < 0)
        {
            distanceRan = transform.position.x - startPoint;
            startPoint = transform.position.x;
            score.IncreaseScore((int)distanceRan);
            scoreDelay = 1;
        }   
        Beat();
        if (health > 0)
        {
            MoveCharacter();
        }
        else if(alive)
        {
            anim.PlaySlideAnimation();
            alive = false;
        //  print("Dead");
            StartCoroutine(LoadNext());
        }


        if (CollidedWithObject())
        {
            {
                coEffect.OnCrash();
                if(damageDelay < 0)
                {
                    health -= 5;
                    damageDelay = 0.5f;
                }
            }
        }
        damageDelay -= Time.deltaTime;
    }

    bool CollidedWithObject()
    {
        return (controller.collisionFlags & CollisionFlags.CollidedSides) != 0;
    }

    void MoveCharacter()
    {
        if (controller.isGrounded)
        {
            if (!isSliding && Input.GetKey(KeyCode.DownArrow))
            {
                controller.radius = 0.1f;
                controller.height = 0.5f;
                anim.PlaySlideAnimation();
            }
            else if (isSliding && !Input.GetKey(KeyCode.DownArrow))
            {
                controller.transform.Translate(0, 0.2f, 0);
                controller.radius = 0.26f;
                controller.height = 1.46f;
            }
            else if (!Input.GetKey(KeyCode.DownArrow))
            {
                anim.PlayRunAnimation(speed / speedAnimRatio);
            }

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

    IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(2);
        score.SaveScore();
        Application.LoadLevel("highscore");
    }

    void Beat()
    {
        float keyHeartRaw = Input.GetAxisRaw("Heart");
        bool keyHeart = Input.GetButtonDown("Heart");
        rate -= Time.deltaTime * rateMul;
        rateMul += Time.deltaTime / 160;
        float beat = 1 - Mathf.Abs(rate);
        float acc = 2;
        indicator = rate / (heart ? 0.45f : 0.25f);
        if (rate < -1.5f)
        {
            health -= 3;
           // print("Loosing health: " + health);
            rate += 1.5f;
        }
        if (keyHeart)
        {
            float timing = Mathf.Abs(rate * acc);
            float bonusscore = (1 - timing) > 0 ? 1 - timing : 0;
            if (first)
            {
                speed += 4 / (speed + 4);
                heart = keyHeartRaw > 0;
                rate = heart ? 0.45f : 0.25f;
                score.IncreaseScore((int)(bonusscore * 25));
                first = false;
            }
            else if (!heart && keyHeartRaw > 0)
            {
                speed += (maxSpeed - 2) / (speed + 2) - timing;
                heart = true;
                SetRateTime();
                score.IncreaseScore((int)(bonusscore * 25));
            }
            else if (heart && keyHeartRaw < 0)
            {
                speed += (maxSpeed - 2) / (speed + 2) - timing;
                heart = false;
                SetRateTime();
                score.IncreaseScore((int)(timing * 5));
            }
            else if (keyHeartRaw != 0 && speed > 0)
            {
                speed -= 1.75f;
                health -= 5;
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
        rate = heart ? 0.45f / rateMul : 0.25f / rateMul;
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
     //   print("crash");
    }

    public void AddScore(int points)
    {
        score.IncreaseScore(points);
    }
}
