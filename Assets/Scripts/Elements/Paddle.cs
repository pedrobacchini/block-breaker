using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private int screenWidthInUnits = 16;
    [SerializeField] private Ball ball;

    // Update is called once per frame
    private void FixedUpdate()
    {
        var paddleXPos = Mathf.Clamp(GetXPos(), 1, screenWidthInUnits - 1);
        transform.position = new Vector2(paddleXPos, transform.localPosition.y);
    }

    private float GetXPos()
    {
        switch (GameMaster.Instance.controlType)
        {
            case ControlType.AutoPlay:
                return GetBallPosition();
            case ControlType.Mouse:
                return GetMousePosInUnits();
            case ControlType.Keyboard:
                return GetKeyboardPos();
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private float GetBallPosition()
    {
        return ball.transform.position.x;
    }

    private float GetMousePosInUnits()
    {
        return Input.mousePosition.x / Screen.width * 16;
    }

    private float GetKeyboardPos()
    {
        return transform.position.x + Time.deltaTime * GameMaster.Instance.paddleSpeed * Input.GetAxis("Horizontal");
    }
}