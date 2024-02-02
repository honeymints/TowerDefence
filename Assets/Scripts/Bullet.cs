using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletData _bulletData;
    private Transform target;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        target = EnemyManager._walkingEnemies[0].GetPoisition();
        if (target == null) target = EnemyManager._flyingEnemies[0].GetPosition();
        
        MoveTowardsPlayer();
    }
    
    public void OnEnable()
    {
        StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(3.5f);
        gameObject.SetActive(false);
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        rb.AddForce(_bulletData.speedShooting*direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var walkingEnemy = collision.gameObject.GetComponent<IWalkingEnemy>();
        var flyingEnemy = collision.gameObject.GetComponent<IFlyingEnemy>();
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.enabled = false;
        }

        if (walkingEnemy!= null)
        {
            walkingEnemy.GetHurt(_bulletData.hitForce);
        }

        if (flyingEnemy!= null)
        {
            flyingEnemy.GetHurt(_bulletData.hitForce);
        }
    }
}
