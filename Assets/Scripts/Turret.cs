using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _target;
    
    [SerializeField] private Transform _shell;
    [SerializeField] private Transform _turretPos;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private TurretData _turretData;
    
    private bool canShoot = false, isInArea = false;
    private float timeLeft=0, timeOfDelay; 

    private void Awake()
    {
        timeLeft = _turretData._timeLeft;
        timeOfDelay = _turretData._timeOfDelay;
    }

    void Update()
    {
        DetectTarget();
        //_target = GameObject.FindGameObjectWithTag("Enemy").transform;
        Rotate();
        Shoot();
        CanShoot();
    }

    private void DetectTarget()
    {
        _target = EnemyManager._walkingEnemies[EnemyManager._walkingEnemies.Count-1].GetPoisition();
    }
    
    public void Shoot()
    {
        if (canShoot && isInArea)
        {
            var bullet = Instantiate(_bulletPrefab, _shell.position, transform.rotation);
            canShoot = false;
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
            Debug.Log("WOOORK");
            isInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isInArea = false;
        }
    }
}
