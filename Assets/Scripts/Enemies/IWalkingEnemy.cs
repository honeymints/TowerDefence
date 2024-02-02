using UnityEngine;

public interface IWalkingEnemy
{ 
    void Attack(); 
    
    void Die();

    void Initialize(WalkingEnemyFactory walkingEnemyData);

    void GetHurt(float damage);
    
    Transform GetPoisition();
}
