using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float launchLocationX = 2f;
    [SerializeField] float launchLocationY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = .5f;

    Vector2 paddleToBallVector;
    private bool hasStarted = false;

    //cached variable
    private AudioSource myAudioSource;
    private Rigidbody2D myRigidbody2D;



    void Start ()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LauchBall();
        }
    }

    private void LauchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(launchLocationX, launchLocationY);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = new Vector2(paddlePosition.x, paddlePosition.y + paddleToBallVector.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0, randomFactor),
            Random.Range(0, randomFactor)
            );

        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myRigidbody2D.velocity += velocityTweak;
            myAudioSource.PlayOneShot(clip);
        }
    }
}
