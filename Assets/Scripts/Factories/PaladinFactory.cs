using UnityEngine;

[CreateAssetMenu(fileName = "PaladinFactory", menuName = "Data/Paladin Factory")]
public class PaladinFactory : WalkingEnemyFactory
{
    public override IWalkingEnemy CreateWalkingEnemy()
    {
        var paladinInstance = GameObject.Instantiate(this.prefab);
        IWalkingEnemy paladin = paladinInstance.GetComponent<Paladin>();
        paladin.Initialize(this);
        return paladin;
    }
}
