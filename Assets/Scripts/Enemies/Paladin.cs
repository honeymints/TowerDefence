using System;
using UnityEngine;
using UnityEngine.AI;

public class Paladin : MonoBehaviour, IWalkingEnemy
{
    [SerializeField] private PaladinFactory paladinData;
    private float _healthPoints;
    private float _hitForce;
    private Animator _animator;
    private Transform target;
    private NavMeshAgent _agent;
    
    private void Start()
    {
        _healthPoints = paladinData.healthPoint;
        _hitForce = paladinData.hitForce;
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
        _animator.Play("Sword Slash");
        target.GetComponent<Tower>().GetDamage(_hitForce);
    }

    public void Die()
    {
        EnemyManager._walkingEnemies.Remove(this);
        Destroy(gameObject);
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
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Castle"))
        {
            Attack();
        }
    }
}
