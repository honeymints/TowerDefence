
using UnityEngine;

public interface IFlyingEnemy
{
    void ThrowBomb();

    void Die();

    void Initialize(FlyingEnemyFactory flyingEnemyData);

    void GetHurt(float damage);

    Transform GetPosition();
}
