using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] public float screenWidthInUnits = 16f;
    [SerializeField] public float minimumBoundary = 1f;
    [SerializeField] public float maximumBoundary = 15f;

    private GameSession gameSession;
    private Ball ball;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos;
        if (gameSession.IsAutoPlay())
        {
            var ballPosition = ball.gameObject.transform.position;
            paddlePos = new Vector2(ballPosition.x, transform.position.y);
            paddlePos.x = Mathf.Clamp(ballPosition.x, minimumBoundary, maximumBoundary);
        }
        else
        {
            float mousePosition = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
            paddlePos = new Vector2(mousePosition, transform.position.y); 
            paddlePos.x = Mathf.Clamp(mousePosition, minimumBoundary, maximumBoundary);

        }
        
        transform.position = paddlePos;
    }
}
