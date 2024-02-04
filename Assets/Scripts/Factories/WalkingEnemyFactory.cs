using UnityEngine;

public abstract class WalkingEnemyFactory : ScriptableObject
{
    public float hitForce;
    public float healthPoint;
    public float hitDelay;
    public GameObject prefab;
    public abstract IWalkingEnemy CreateWalkingEnemy();
}
