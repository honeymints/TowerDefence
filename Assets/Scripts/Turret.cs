using System;
using JetBrains.Annotations;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [CanBeNull] private Transform _target;
    
    [SerializeField] private Transform _shell;
    [SerializeField] private Transform _turretPos;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private TurretData _turretData;
    private int enemyCount;
    private bool isFlyingEnemyExist=false;
    private bool isWalkingEnemyExist=false;
    private bool canShoot = false, isInArea = false;
    private float timeLeft=0, timeOfDelay; 
    
    private void Awake()
    {
        timeLeft = _turretData._timeLeft;
        timeOfDelay = _turretData._timeOfDelay;
    }

    void Update()
    {
        if (EnemyManager._walkingEnemies.Count != 0)
        {
            isWalkingEnemyExist=true;
        }
        else
        {
            isWalkingEnemyExist=false;
        }
        if (EnemyManager._flyingEnemies.Count != 0)
        {
            isFlyingEnemyExist=true;
        }
        else
        {
            isFlyingEnemyExist=false;
        }
        DetectTarget();
        CanShoot();
        Shoot();
        Rotate();
    }
    
    private void DetectTarget()
    {
        if(isWalkingEnemyExist) _target = EnemyManager._walkingEnemies[0].GetPoisition();
        if (EnemyManager._walkingEnemies == null) _target = EnemyManager._flyingEnemies[0].GetPosition();
    }
    
    public void Shoot()
    {
        if (canShoot && isInArea)
        {
            var bullet = Instantiate(_bulletPrefab, _shell.position, transform.rotation);
            timeLeft = timeOfDelay;
        }
    }

    public void CanShoot()
    {
        if (timeLeft>0)
        {
            canShoot = false;
            timeLeft -= Time.deltaTime;
        }
        else
        {
            canShoot = true;
        }
    }

    public void Rotate()
    {
        Vector3 rotationDirection = (_target.position - _turretPos.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(rotationDirection);
        _turretPos.rotation = Quaternion.Slerp(_turretPos.rotation, rotation, _turretData._rotationSpeed * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isInArea = true;
        }
    }
}
