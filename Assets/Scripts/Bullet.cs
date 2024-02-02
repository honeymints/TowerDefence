using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Color color;
    private Transform target;
    [SerializeField] private BulletData _bulletData;
    private Rigidbody rb;

    private Collider coll;
    // Start is called before the first frame update

    private void Update()
    {
        target = GameObject.FindWithTag("Enemy").transform;
        MoveTowardsPlayer();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }
    
    public void OnEnable()
    {
        StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        //yield return new WaitForSeconds(3.5f);
        yield return new WaitForSeconds(3.5f);
        gameObject.SetActive(false);
    }
    
    private IEnumerator MoveTowardsPLayer()
    {
        while (transform.position != target.position)
        {
            Vector3 currentPosition = Vector3.MoveTowards(transform.position, target.position,
                _bulletData._speedShooting*Time.deltaTime);
            transform.position = currentPosition;
            yield return null;
        }
    }
    
    private void MoveTowardsPlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        rb.AddForce(_bulletData._speedShooting*direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.enabled = false;
        }
    }
}
