using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameMaster.Instance.TriggerLoseCollider();
    }
}
