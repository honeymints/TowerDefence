using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Amy : MonoBehaviour, IFlyingEnemy
{
    [SerializeField] private AmyFactory amyData;
    [SerializeField] private PoolingObject _pooledObj;
    [SerializeField] private GameObject slider;
    private float _healthPoints;
    private float _nextAttack=-1;
    private float _speedOfFlying;
    private float _throwDelay;
    private float _bombForce;
    private Transform _target;
    private void Start()
    {
        _healthPoints = amyData.healthPoint;
        _speedOfFlying = amyData.speedOfFlying;
        _throwDelay = amyData.throwDelay;
        _bombForce = amyData.bombForce;
        _target = GameObject.FindWithTag("Castle").transform;
    }

    private void Update()
    {
        FlyTowards();
    }

    public void ThrowBomb()
    {
        if (Time.time > _nextAttack)
        {
            _pooledObj.Spawn(transform, transform.rotation, amyData.bombPrefab);
            _nextAttack = _throwDelay + Time.time;
        }
    }

    public void Die()
    { 
        EnemyManager._flyingEnemies.Remove(this);
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
            slider.GetComponent<HealthBarManager>().TakeDamage(_healthPoints);
        }
        else
        {
            _healthPoints = 0;
            Die();
        }
    }

    public void FlyTowards()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position,_speedOfFlying*Time.deltaTime);
    } 
    
    public Transform GetPosition()
    {
        return transform;
    }

    private void OnCollisionStay(Collision collision)
    {
       ThrowBomb(); 
    }
}
