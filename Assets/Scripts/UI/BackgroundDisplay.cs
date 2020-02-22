using UnityEngine;

public class BackgroundDisplay : MonoBehaviour
{
    private void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = GameMaster.Instance.CurrentLevel.color;
    }
}
