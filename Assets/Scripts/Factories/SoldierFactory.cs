using UnityEngine;

[CreateAssetMenu(fileName = "Soldierfactory", menuName = "Data/Soldier Factory")]
public class SoldierFactory : WalkingEnemyFactory
{
    public override IWalkingEnemy CreateWalkingEnemy()
    {
        var soldierInstance = GameObject.Instantiate(this.prefab);
        IWalkingEnemy soldier = soldierInstance.GetComponent<Soldier>();
        soldier.Initialize(this);
        return soldier;
    }
}
