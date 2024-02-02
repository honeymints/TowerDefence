 using UnityEngine;

 public abstract class FlyingEnemyFactory : ScriptableObject
 {
     public float hitForce;
     public float healthPoint;
     public GameObject prefab;
     public abstract IFlyingEnemy CreateFlyingEnemy();
 }
