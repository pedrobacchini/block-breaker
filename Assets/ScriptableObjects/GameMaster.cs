using System.Collections.Generic;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ControlType
{
    Keyboard,
    Mouse,
    AutoPlay,
}

[CreateAssetMenu(fileName = "New Game Master", menuName = "Singletons/Game Master")]
public class GameMaster : SingletonScriptableObject<GameMaster>
{
    // Configure parameters
    [SerializeField] public ControlType controlType = ControlType.Mouse;
    [Range(0.1f, 10f)] [SerializeField] public float gameSpeed = 1f;
    [Range(0.1f, 20f)] [SerializeField] public float paddleSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 80;
    
    // State variables
    [OdinSerialize] [ReadOnly] private IntReactiveProperty _currentScore = new IntReactiveProperty(0);
    public static ReactiveProperty<int> CurrentScore => Instance._currentScore;
    
    [OdinSerialize] [ReadOnly] private IntReactiveProperty _currentLives = new IntReactiveProperty(0);
    public static ReactiveProperty<int> CurrentLives => Instance._currentLives;

    [OdinSerialize] [ReadOnly] private int _currentIndexLevel = 0;
    [OdinSerialize] private List<LevelScriptableObject> _levels = new List<LevelScriptableObject>();
    public LevelScriptableObject CurrentLevel => _levels[_currentIndexLevel]; 

    public void AddToScore()
    {
        _currentScore.Value += pointsPerBlockDestroyed;
    }

    public void AddLive()
    {
        _currentLives.Value++;
    }

    public void TriggerLoseCollider()
    {
        _currentLives.Value--;
        if (_currentLives.Value < 0)
        {
            SceneManager.LoadScene("Game Over");
            Cursor.visible = true;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void LoadNextScene()
    {
        _currentIndexLevel++;
        SceneManager.LoadScene(SceneManager.sceneCount);
    }

    [UsedImplicitly]
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        ResetGame();
    }

    [UsedImplicitly]
    public void setMouseControlType()
    {
        controlType = ControlType.Mouse;
    }
    
    [UsedImplicitly]
    public void setKeyboardControlType()
    {
        controlType = ControlType.Keyboard;
    }

    [UsedImplicitly]
    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        Instance.ResetGame();
    }

    private void ResetGame()
    {
        _currentIndexLevel = 0;
        _currentScore.Value = 0;
        _currentLives.Value = 0;
    }
}