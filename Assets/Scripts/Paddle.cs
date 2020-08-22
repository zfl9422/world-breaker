using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Implementation idea
 * Paddle can tilt via Arrow keys (or A and D) 
 * reset to original position possible
 * introduces more control to where the ball is to be bounced
 */

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidth = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float paddleTiltAngle = 15f;

    // Cache reference
    GameState gs;
    Ball ball;
    Vector3 paddleRotation;

    // Start is called before the first frame update
    void Start()
    {
        gs = FindObjectOfType<GameState>();
        ball = FindObjectOfType<Ball>();
        paddleRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);

        paddlePosition.x = Mathf.Clamp(GetXPosition(), minX, maxX);
        transform.position = paddlePosition;

        // Paddle tilt only happens after the ball has been launched
        if (ball.GetBallLaunched())
        {
            PaddleTilt();
        }
    }

    private float GetXPosition()
    {
        if (gs.getAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidth;
        }
        
    }

    private void PaddleTilt()
    {
        // Suggestion: smoother tilt: add tilt angle by small degrees until
        // a cap is reached

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            paddleRotation.z = paddleTiltAngle;
            transform.eulerAngles = paddleRotation;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            paddleRotation.z = paddleTiltAngle * -1;
            transform.eulerAngles = paddleRotation;
        }
        else
        {
            paddleRotation.z = 0f;
            transform.eulerAngles = paddleRotation;
        }
    }
}
