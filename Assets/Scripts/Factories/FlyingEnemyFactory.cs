 using UnityEngine;
 using UnityEngine.UI;

 public abstract class FlyingEnemyFactory : ScriptableObject
 {
     public float healthPoint;
     public float speedOfFlying;
     public float bombForce;
     public float throwDelay;
     public GameObject prefab;
     public GameObject bombPrefab;
     public abstract IFlyingEnemy CreateFlyingEnemy();
 }
