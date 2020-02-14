using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "BlockBreaker/LevelData")]
public class LevelScriptableObject : ScriptableObject
{
    public new string name;
    public Sprite background;
    public Color color;
    public GameObject blocksPrefab;
}