using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFactory", menuName = "Data/Enemy Factory")]
public class EnemyFactory : ScriptableObject
{
    public FlyingEnemyFactory flyingEnemyFactory;
    public WalkingEnemyFactory[] walkingEnemyFactory;

    [CanBeNull]
    public IFlyingEnemy CreateFlyingEnemy(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Amy: 
                return flyingEnemyFactory.CreateFlyingEnemy();
            default: 
                return null;
        }
    }

    [CanBeNull]
    public IWalkingEnemy CreateWalkingEnemy(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Paladin:
                return walkingEnemyFactory[0].CreateWalkingEnemy();
            case EnemyType.Soldier:
                return walkingEnemyFactory[1].CreateWalkingEnemy();
            default:
                return null;
        }
    }
}
