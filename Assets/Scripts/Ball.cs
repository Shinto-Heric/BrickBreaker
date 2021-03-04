using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f,yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    float randomness = 0.5f;
    AudioSource mySound;
    Rigidbody2D rigidBody2D;

    Vector2 diffBetwenPaddleAndBall;
    bool hasStarted = false;
    void Start()
    {
        mySound = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        diffBetwenPaddleAndBall = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockTheBall();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockTheBall()
    {
        Vector2 paddlePositon = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePositon + diffBetwenPaddleAndBall;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak =new  Vector2(UnityEngine.Random.Range(0f, randomness), UnityEngine.Random.Range(0f, randomness));
        if(hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)]; 
            mySound.PlayOneShot(clip);
            rigidBody2D.velocity += velocityTweak;
        }
    }
}
