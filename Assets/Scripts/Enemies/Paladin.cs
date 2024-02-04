using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Paladin : MonoBehaviour, IWalkingEnemy
{
    [SerializeField] private PaladinFactory paladinData;
    [SerializeField] private GameObject slider;
    private float _healthPoints;
    private float _hitForce;
    private float _hitDelay;
    private float nextAttack=-1;
    private Animator _animator;
    private Transform target;
    private NavMeshAgent _agent;
    

    private void Start()
    {
        _healthPoints = paladinData.healthPoint;
        _hitForce = paladinData.hitForce;
        _hitDelay = paladinData.hitDelay;
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
        if (Time.time>nextAttack)
        {
            _agent.isStopped = true;
            _animator.Play("Sword Slash");
            target.GetComponent<Tower>().GetDamage(_hitForce);
            nextAttack = _hitDelay + Time.time;
        }
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
