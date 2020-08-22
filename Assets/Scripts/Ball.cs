using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] Vector2 launchPower = new Vector2(2f, 15f);
    // Alternatively -- float xDirection and float yDirection 

    [SerializeField] AudioClip[] collisionSounds;
    [SerializeField] float randomVelocity = 0.2f;

    Vector2 ballOnPaddle;
    bool ballLaunched;

    // cache references
    AudioSource audioSource;
    Rigidbody2D ballRigidBody;



    // Start is called before the first frame update
    void Start()
    {
        // displacement of the ball above the paddle
        ballOnPaddle = transform.position - paddle.transform.position;
        // ballLaunched = false;    false on create
        audioSource = GetComponent<AudioSource>();
        ballRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballLaunched == false)
        {
            BallOnPaddle();
            LaunchBall();
        }
    }

    private void BallOnPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + ballOnPaddle;
    }

    private void LaunchBall()
    {
        // left click or spacebar to launch
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            ballRigidBody.velocity = launchPower;
            ballLaunched = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // UnityEngine random
        Vector2 velocityAdjustment = new Vector2(Random.Range(0f, randomVelocity), 
            Random.Range(0f, randomVelocity));

        if (ballLaunched)
        {
            AudioClip clip = collisionSounds[UnityEngine.Random.Range(0, collisionSounds.Length)];
            audioSource.PlayOneShot(clip);
            ballRigidBody.velocity += velocityAdjustment;
        }
    }

    public bool GetBallLaunched()
    {
        return ballLaunched;
    }
}
