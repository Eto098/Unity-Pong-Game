using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    public void OnTriggerEnter2D(Collider2D other)
    {
         if(other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddle>().isRight;

            if(isRight == true && direction.x > 0)
            {
                speed += 1f;
                direction.x *= -1;
            }
            if(isRight == false && direction.x < 0)
            {
                speed += 1f;
                direction.x *= -1;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < GameManager.BottomLeft.y + radius && direction.y < 0)
        {
            direction.y *= -1;
        }
        if (transform.position.y > GameManager.UpperRight.y - radius && direction.y > 0)
        {
            direction.y *= -1;
        }
        if (transform.position.x < GameManager.BottomLeft.x + radius && direction.x < 0)
        {
            //Debug.Log("Right Player Wins!");
            //Time.timeScale = 0;
            //enabled = false;
            SceneManager.LoadScene("MainMenu");
        }
        if (transform.position.x > GameManager.UpperRight.x - radius && direction.x > 0)
        {
            //Debug.Log("Left Player Wins!");
            //Time.timeScale = 0;
            //enabled = false;
            SceneManager.LoadScene("MainMenu");
        }

        transform.Translate(Time.deltaTime * speed * direction);
    }
}
