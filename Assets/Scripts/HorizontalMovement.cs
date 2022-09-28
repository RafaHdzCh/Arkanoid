using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] GameObject mainMenuGO;
    [SerializeField] GameObject gameGO;

    private float paddleSpeed = 750f;
    [SerializeField] Rigidbody2D paddleRigidbody2D;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        paddleRigidbody2D.velocity = Vector2.right * horizontal * paddleSpeed * Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameGO.SetActive(false);
            mainMenuGO.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
