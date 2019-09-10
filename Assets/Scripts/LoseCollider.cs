using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private GameSession _gameSession;
    
    private void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _gameSession.TriggerLoseCollider();
    }
}
