using System;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : MonoBehaviour, IWalkingEnemy
{
    [SerializeField] private SoldierFactory soldierData;
    private float _healthPoints;
    private float _hitForce;
    private Animator _animator;
    private Transform target;
    private NavMeshAgent _agent;

    private void Start()
    {
        _healthPoints = soldierData.healthPoint;
        _hitForce = soldierData.hitForce;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Castle").transform;
    }

    private void Update()
    {
        _agent.destination = target.position;
    }

    public void Attack()
    {
        _animator.Play("Shooting");
        target.GetComponent<Tower>().GetDamage(_hitForce);
    }

    public void Die()
    {
        _animator.Play("Dying");
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

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Castle"))
        {
            Attack();
        }
    }
}
