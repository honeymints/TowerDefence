using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfiguration",menuName = "Data/WaveData")]
public class WaveConfiguration : ScriptableObject
{
    public int enemyCount;
    public float spawnDelay;
    public EnemyType enemyType;
}

public enum EnemyType
{
    Paladin,
    Soldier,
    Amy,
}