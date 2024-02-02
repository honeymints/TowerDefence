using UnityEngine;
using UnityEngine.AI;

public class Amy : MonoBehaviour, IFlyingEnemy
{
    [SerializeField] private AmyFactory amyData;
    private void Start()
    {
        
    }
    
    public void ThrowBomb()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public void Initialize(FlyingEnemyFactory amyData)
    {
        this.amyData = (AmyFactory)amyData;
    }

    public void GetHurt(float damage)
    {
        throw new System.NotImplementedException();
    }
}
