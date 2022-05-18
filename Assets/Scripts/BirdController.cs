using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] float rotationRate = 10f;
    [SerializeField] float thrust = 1f;

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private bool jump = false;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (GameManager.Instance.CurrentStatus == GameManager.Status.RUNNING)
        {
            EnableBird();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (GameManager.Instance.CurrentStatus == GameManager.Status.GAME_OVER)
            {
                if (Application.platform == RuntimePlatform.Android)
                {
                    return;
                }
                GameManager.Instance.RestartGame();
            }

            if (GameManager.Instance.CurrentStatus == GameManager.Status.START)
            { 
                GameManager.Instance.StartGame();
                EnableBird();
            }

            jump = true;
        }
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            rigidbody2d.AddForce(new Vector2(0, thrust), ForceMode2D.Force);
            AudioManager.PlayJumpSound();
        }

        RotateBird();

        jump = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreZone"))
        {
            GameManager.Instance.IncreaseScore();
            AudioManager.PlayScoreSound();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundaries") || collision.gameObject.CompareTag("Obstacles"))
        {
            AudioManager.PlayDeathSound();
            GameManager.Instance.EndGame();
            animator.enabled = false;
        }
    }


    private void RotateBird()
    {
        float v = transform.GetComponent<Rigidbody2D>().velocity.y;

        float rotate = Mathf.Min(Mathf.Max(-90, v * rotationRate + 60), 30);

        transform.rotation = Quaternion.Euler(0f, 0f, rotate);
    }

    public void EnableBird()
    {
        rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
    }
}
