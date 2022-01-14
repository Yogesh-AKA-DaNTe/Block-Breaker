using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f; // Total Width of screen
    [SerializeField] float minX = 1f; // Left bound for paddle
    [SerializeField] float maxX = 15f; //Right bound for paddle

    GameStatus myGameStatus; // For storing GameStatus
    Ball myBall; // For storing Ball

    void Start()
    {
        // Assigning GameStatus and Ball
        myGameStatus = FindObjectOfType<GameStatus>();
        myBall = FindObjectOfType<Ball>();
    }

    void Update()
    {
        // Updates the position of paddle according to position of mouse
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetPosX(), minX, maxX);
        transform.position = paddlePos;
    }

    // Function to get the X Position of mouse
    private float GetPosX()
    {
        if (myGameStatus.IsAutoPlayEnabled())
        {
            return myBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
