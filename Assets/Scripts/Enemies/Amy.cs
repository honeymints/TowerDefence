using UnityEngine;
using UnityEngine.AI;

public class Amy : MonoBehaviour, IFlyingEnemy
{
    [SerializeField] private AmyFactory amyData;
    private float _healthPoints;
    private Animator _animator;
    private void Start()
    {
        _healthPoints = amyData.healthPoint;
        _animator = GetComponent<Animator>();
    }
    
    public void ThrowBomb()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
       Destroy(gameObject);
    }

    public void Initialize(FlyingEnemyFactory amyData)
    {
        this.amyData = (AmyFactory)amyData;
    }

    public void GetHurt(float damage)
    {
        if (_healthPoints > 0)
        {
            _healthPoints -= damage;
        }
        else
        {
            _healthPoints = 0;
            Die();
        }
    }

    public Transform GetPosition()
    {
        return transform;
    }
}
