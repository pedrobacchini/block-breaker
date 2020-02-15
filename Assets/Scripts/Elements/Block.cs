using UnityEngine;

public class Block : MonoBehaviour
{
    // Configure parameters
    [SerializeField] private AudioClip breakSound = null;
    [SerializeField] private GameObject sparklesVfx = null;
    [SerializeField] private Sprite[] hitsSprites = null;

    // Cached component references
    private Level _level;

    // State variables
    [SerializeField] private int timesHits = 0; //TODO only serialized for debug purpose
    private int _maxHits;

    private void Start()
    {
        _maxHits = hitsSprites.Length + 1;
        
        _level = FindObjectOfType<Level>();

        if (CompareTag("Breakable")) _level.CountBreakableBlock();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (CompareTag("Breakable")) HandlerHit();
    }

    private void HandlerHit()
    {
        timesHits++;
        if (timesHits >= _maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        var nextHitSprite = hitsSprites[timesHits - 1];
        if (nextHitSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitsSprites[timesHits - 1];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array Hits Sprites in " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        TriggerSfxEffect();
        TriggerVfxEffect();
        Destroy(gameObject);
        _level.BlockDestroyed();
        GameMaster.Instance.AddToScore();
    }

    private void TriggerSfxEffect()
    {
        if (Camera.main != null) AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 1);
    }

    private void TriggerVfxEffect()
    {
        var transform1 = transform;
        var instantiate = Instantiate(sparklesVfx, transform1.position, transform1.rotation);
        Destroy(instantiate, 2f);
    }
}