using System;
using UnityEngine;
using UnityEngine.AI;

public class Paladin : MonoBehaviour, IWalkingEnemy
{
    [SerializeField] private PaladinFactory paladinData;
    private float _healthPoints;
    private float _hitForce;
    private Transform target;
    private NavMeshAgent _agent;
    
    private void Start()
    {
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
        throw new System.NotImplementedException();
    }

    public void DetectTurret()
    {
        throw new NotImplementedException();
    }

    public void Initialize(WalkingEnemyFactory walkingEnemyData)
    {
        paladinData = (PaladinFactory)walkingEnemyData;
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
}
