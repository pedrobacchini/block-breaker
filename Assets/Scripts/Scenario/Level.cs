using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    // State variables
    [SerializeField] private int breakableBlocks = 0; //TODO only serialized for debug purpose
    
    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Start()
    {
        Instantiate(GameMaster.Instance.CurrentLevel.blocksPrefab, Vector3.zero, Quaternion.identity);
    }

    private void Update()
    {
        Time.timeScale = GameMaster.Instance.gameSpeed;
    }

    public void CountBreakableBlock()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks > 0) return;
        GameMaster.Instance.LoadNextScene();
        GameMaster.Instance.AddLive();
    }
}