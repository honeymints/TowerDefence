using UnityEngine;

public abstract class WalkingEnemyFactory : ScriptableObject
{
    public float hitForce;
    public float healthPoint;
    public GameObject prefab;
    public abstract IWalkingEnemy CreateWalkingEnemy();
}
