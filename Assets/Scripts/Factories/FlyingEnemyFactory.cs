 using UnityEngine;
 using UnityEngine.UI;

 public abstract class FlyingEnemyFactory : ScriptableObject
 {
     public float hitForce;
     public float healthPoint;
     public float speedOfFlying;
     public GameObject prefab;
     public abstract IFlyingEnemy CreateFlyingEnemy();
 }
