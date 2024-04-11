using UnityEngine;

[CreateAssetMenu(menuName = "Config/Level Config", fileName = "Level Config")]
public class LevelConfig : ScriptableObject
{
    [field: SerializeField] public int LevelTime { get; private set; }
    [field: Space(5)]
    
    [field: SerializeField] public int CoinsAmount { get; private set; }
    [field: SerializeField] public int LivesAmount { get; private set; }
}