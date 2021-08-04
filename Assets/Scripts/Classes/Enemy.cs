using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyState enemyState = EnemyState.Idle;

    static float followDistance = 10f;
    static float chaseSpeed = 0.1f;

    void Awake()
    {
        GameManager.Instance.AddEnemyToList(this);
    }

    void Update()
    {
        switch (enemyState)
        {
            case EnemyState.Idle:
            if(CanSeePlayer())
            {
                enemyState = EnemyState.Chase;
            }
            else
            {
                // Just Wait
            }
            break;
            case EnemyState.Chase:
            
            if(CanSeePlayer())
            {
                FollowPlayer();
            }
            else
            {
                enemyState = EnemyState.Idle;
            }
            break;
        }     
    }

    bool CanSeePlayer()
    {
        if(Vector3.Distance(GameManager.Instance.player.gameObject.transform.position, transform.position) < followDistance)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.player.transform.position, chaseSpeed);
    }

    public void DestroyEnemy()
    {
        GameManager.Instance.RemoveEnemyFromList(this);
        Destroy(gameObject);
    }

    public enum EnemyState : byte
    {
        Idle,
        Chase
    }
}
