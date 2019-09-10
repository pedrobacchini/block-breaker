using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private int screenWidthInUnits = 0;

    // Cached component references
    private GameSession _gameSession;
    private Ball _ball;

    private void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
        _ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    private void Update()
    {
        var paddleXPos = Mathf.Clamp(GetXPos(), 1, screenWidthInUnits - 1);
        transform.position = new Vector2(paddleXPos, transform.localPosition.y);
    }

    private float GetXPos()
    {
        return _gameSession.IsAutoPlayEnable() ? GetBallPosition() : GetMousePosInUnits();
    }

    private float GetBallPosition()
    {
        return _ball.transform.position.x;
    }

    private static float GetMousePosInUnits()
    {
        return Input.mousePosition.x / Screen.width * 16;
    }
}