using UnityEngine;

[CreateAssetMenu(fileName = "AmyFactory", menuName = "Data/Amy Factory")]
public class AmyFactory : FlyingEnemyFactory 
{
    public override IFlyingEnemy CreateFlyingEnemy()
    {
        var flyingEnemyInstance = GameObject.Instantiate(this.prefab);
        IFlyingEnemy flyingEnemy = flyingEnemyInstance.GetComponent<IFlyingEnemy>();
        flyingEnemy.Initialize(this);
        return flyingEnemy;
    }
}