using System;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : MonoBehaviour, IWalkingEnemy
{
    [SerializeField] private SoldierFactory soldierData;
    private float _healthPoints;
    private float _hitForce;
    private NavMeshAgent _agent;
    private Transform target;
    private IWalkingEnemy _walkingEnemyImplementation;

    private void Start()
    {
        _healthPoints = soldierData.healthPoint;
        _hitForce = soldierData.hitForce;
        _agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Castle").transform;
    }

    private void Update()
    {
        _agent.destination = target.position;
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        EnemyManager._walkingEnemies.Remove(this);
        Destroy(gameObject);
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

    public Transform GetPoisition()
    {
        return transform;
    }

    public void Initialize(WalkingEnemyFactory walkingEnemyFactory)
    {
        soldierData = (SoldierFactory)walkingEnemyFactory;
    }
}
