using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameSession : MonoBehaviour
{
    // Configure parameters
    [Range(0.1f, 10f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 80;
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI velocityText = null;
    [SerializeField] private TextMeshProUGUI livesText = null;
    [SerializeField] private bool autoPlay = false;
    
    // State variables
    private int _currentScore = 0;
    private int _currentLives = 0;

    // Singleton DontDestroyOnLoad
    private void Awake()
    {

        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Cursor.visible = false;
        scoreText.text = _currentScore.ToString();
        livesText.text = _currentLives.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        _currentScore += pointsPerBlockDestroyed;
        scoreText.text = _currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void UpdateVelocity(float velocity)
    {
        velocityText.text = velocity.ToString();
    }

    public bool IsAutoPlayEnable()
    {
        return autoPlay;
    }

    public void AddLive()
    {
        _currentLives++;
        livesText.text = _currentLives.ToString();
    }

    public void TriggerLoseCollider()
    {
        _currentLives--;
        if (_currentLives < 0)
        {
            SceneManager.LoadScene("Game Over");
            Cursor.visible = true;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            livesText.text = _currentLives.ToString();
        }
    }
}