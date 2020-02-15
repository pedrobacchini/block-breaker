using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private int screenWidthInUnits = 0;
    [SerializeField] private float velocity = 10;
    private Ball ball;
    private GameSession gameSession;

    #endregion

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    private void FixedUpdate()
    {
        switch (GameManager.Instance.controlType)
        {
            case ControlType.Keyboard:
                KeyboardControl();
                break;
            case ControlType.Mouse:
                MouseControl();
                break;
        }
    }

    #region PUBLIC_METHODS

    public void KeyboardControl()
    {
        var positionViewport = Camera.main.WorldToViewportPoint(transform.position);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("move for left");
            if (positionViewport.x <= .045f)
            {
                Debug.Log("out of screen");
                return;
            }

            Debug.Log("move for left");
            float newXPosition = transform.position.x;
            newXPosition -= Time.deltaTime * velocity;
            transform.position = new Vector2(newXPosition, transform.localPosition.y);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (positionViewport.x >= .95f)
            {
                Debug.Log("out of screen");
                return;
            }

            Debug.Log("move for right");
            float newXPosition = transform.position.x;
            newXPosition += Time.deltaTime * velocity;
            transform.position = new Vector2(newXPosition, transform.localPosition.y);
        }

        Debug.Log($"position viewport:: {positionViewport.x}");
    }

    public void MouseControl()
    {
        var paddleXPos = Mathf.Clamp(GetMovimentType(), 1, screenWidthInUnits - 1);
        transform.position = new Vector2(paddleXPos, transform.localPosition.y);
    }

    #endregion

    #region PRIVATE_METHODS

    private float GetMovimentType()
    {
        float valueForReturn = gameSession.IsAutoPlayEnable() ? GetBallPosition() : GetUserPosition();
        //Debug.Log($"GetXPos:: {valueForReturn}");
        return gameSession.IsAutoPlayEnable() ? GetBallPosition() : GetUserPosition();
    }

    private float GetBallPosition()
    {
        return ball.transform.position.x;
    }

    private static float GetUserPosition()
    {
        float valueForReturn = Input.mousePosition.x / Screen.width * 16;
        //Debug.Log($"GetMousePosInUnits:: {valueForReturn}");
        return valueForReturn;
    }

    #endregion
}