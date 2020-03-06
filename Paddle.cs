using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;

    float height;
    string input;
    Vector2 pos;
    public bool isRight;

    public void Init(bool isRightPaddle)
    {
        Vector2 position = Vector2.zero;
        isRight = isRightPaddle;

        if(isRightPaddle)
        {
            position = new Vector2(GameManager.UpperRight.x,0);
            position -= Vector2.right * transform.localScale.x;
            input = "PaddleRight";
        }
        else
        {
            position = new Vector2(GameManager.BottomLeft.x, 0);
            position += Vector2.right * transform.localScale.x;
            input = "PaddleLeft";
        }

        transform.position = position;
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        height = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        float move = speed * Time.deltaTime * Input.GetAxis(input);

        if(transform.position.y < GameManager.BottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        if(transform.position.y > GameManager.UpperRight.y - height / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}
