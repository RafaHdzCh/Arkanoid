using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float ballSpeed = 10f;
    [SerializeField] Rigidbody2D ballRigidbody2D;
    [SerializeField] GameObject paddleGO;
    [SerializeField] Transform ballSpawn;
    [SerializeField] ArkanoidUI arkanoidUI;
    [SerializeField] GameObject gameOverGO;
    [SerializeField] GameObject grid;
    [SerializeField] AudioSource shotSound;
    [SerializeField] AudioSource gameOverSound;

    void Start()
    {
        Invoke(nameof(LaunchTheBall), 1f);
        StartCoroutine(UpgradeDifficulty());
    }

    IEnumerator UpgradeDifficulty()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            ballSpeed *= 1.005f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shotSound.Play();
        if (collision.gameObject != paddleGO) return;
        float x = hitFactor(this.transform.position,
                            collision.transform.position,
                            collision.collider.bounds.size.x);
        Vector2 direction = new Vector2(x, 1).normalized;
        ballRigidbody2D.velocity = direction * ballSpeed;
    }

    float hitFactor(Vector2 ball, Vector2 paddle, float paddleWidth)
    {
        return ((ball.x - paddle.x) / paddleWidth);
    }

    public void LaunchTheBall()
    {
        ballRigidbody2D.velocity = Vector2.up * ballSpeed;
    }

    public void ResetBall()
    {
        if(arkanoidUI.liveCounter >= 1)
        {
            arkanoidUI.liveCounter--;
            transform.position = ballSpawn.position;
            ballRigidbody2D.velocity = Vector2.zero;
            ballSpeed = 10f;
            Invoke(nameof(LaunchTheBall), 2f);
        }
        else
        {
            Destroy(this.gameObject);
            grid.SetActive(false);
            gameOverGO.SetActive(true);
        }
    }
}
