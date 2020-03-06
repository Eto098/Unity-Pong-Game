using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Paddle paddle;
    public Ball ball;
    public static Vector2 BottomLeft;
    public static Vector2 UpperRight;

    // Start is called before the first frame update
    void Start()
    {
        BottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        UpperRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Instantiate(ball);

        Paddle paddleright = Instantiate(paddle) as Paddle;
        paddleright.Init(true);

        Paddle paddleleft = Instantiate(paddle) as Paddle;
        paddleleft.Init(false);

    }
}
