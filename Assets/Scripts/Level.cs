using UnityEngine;

public class Level : MonoBehaviour
{
    // Cached component references
    private SceneLoader _sceneLoader;
    private GameSession _gameSession;

    // State variables
    [SerializeField] private int breakableBlocks = 0; //TODO only serialized for debug purpose

    private void Start()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
        _gameSession = FindObjectOfType<GameSession>();
    }

    public void CountBreakableBlock()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks > 0) return;
        _sceneLoader.LoadNextScene();
        _gameSession.AddLive();
    }
}