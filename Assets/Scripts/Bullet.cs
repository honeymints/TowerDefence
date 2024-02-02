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
    
    // Start is called before the first frame update

    private void Update()
    {
        target = GameObject.FindWithTag("Enemy").transform;
        MoveTowardsPlayer();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

    private void HitPlayer(Collision collision)
    {
        
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
