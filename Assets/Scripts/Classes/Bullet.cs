using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class Bullet : MonoBehaviour, IPoolable
{
    Vector3 bulletDirection;
    
    [SerializeField]
    Rigidbody body;

    static float bulletSpeed = 10f;

    public void SetDirection(Vector3 target)
    {
        var direction = target - transform.position;
        bulletDirection = direction.normalized;
        body.velocity = bulletDirection * bulletSpeed;
    }

    public void OnSpawn()
    {
        LeanPool.Despawn(gameObject, 10f);
    }

    public void OnDespawn()
    {
        body.velocity = Vector3.zero;
        body.Sleep();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Enemy")
        {
            
            collision.collider.gameObject.GetComponent<Enemy>().DestroyEnemy();
        }

        LeanPool.Despawn(gameObject);
    }

}
