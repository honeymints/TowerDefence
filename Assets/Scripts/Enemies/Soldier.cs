using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Soldier : MonoBehaviour, IWalkingEnemy
{
    [SerializeField] private SoldierFactory soldierData;
    [SerializeField] private GameObject slider;
    private float _healthPoints;
    private float _hitForce;
    private float nextAttack=-1;
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
        MoveTowards();
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
            slider.GetComponent<HealthBarManager>().TakeDamage(_healthPoints);
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
    
    public void MoveTowards()
    {
        _agent.isStopped = false;
        _agent.destination = target.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Castle"))
        {
            Attack();
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Castle"))
        {
            MoveTowards();
        }
    }
}
