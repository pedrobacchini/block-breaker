using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Cached component references
    private GameSession _gameSession;

    private void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        if (_gameSession != null)
            _gameSession.ResetGame();
    }

    #region BUTTON_METHODS

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    #endregion
}