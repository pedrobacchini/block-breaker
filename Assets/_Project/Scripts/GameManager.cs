using UnityEngine;

public enum ControlType
{
    Keyboard,
    Mouse
}

public class GameManager : MonoBehaviour
{
    #region VARIABLES

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance is null)
            {
                instance = new GameObject("GameManager_Created", typeof(GameManager)).GetComponent<GameManager>();
            }

            return instance;
        }
    }

    public ControlType controlType;

    #endregion

    #region MONOBHEVIOUR_METHODS

    private void Awake()
    {
        instance = this;
    }

    #endregion
}