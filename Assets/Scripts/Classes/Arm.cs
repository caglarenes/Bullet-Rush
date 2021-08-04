using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class Arm : MonoBehaviour
{
    [SerializeField]
    Collider coll;
    WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

    public GameObject bulletPrefab;

    void Start()
    {
        StartCoroutine("AutoShootEnemies");
    }

    IEnumerator AutoShootEnemies()
    {
        GameObject nearestEnemy;
        while(true)
        {
            nearestEnemy = FindNearestEnemy();

            if(nearestEnemy is null)
            {
                yield return null;
                continue;
            }
            else
            {
                ShootNearestEnemy(nearestEnemy);
                yield return waitForSeconds;
            }
        }
    }

    GameObject FindNearestEnemy()
    {
        int maxColliders = 1;
        int layerMask = 1 << 7;
        Collider[] hitColliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, 5f, hitColliders, layerMask);

        if(numColliders == 0)
        {
            return null;
        }
        else
        {
            return hitColliders[0].gameObject;
        }
    }

    void ShootNearestEnemy(GameObject nearestEnemy)
    {
        GameObject createdBullet = LeanPool.Spawn(bulletPrefab, transform.position, Quaternion.identity);
        createdBullet.GetComponent<Bullet>().SetDirection(nearestEnemy.transform.position);
    }
}
