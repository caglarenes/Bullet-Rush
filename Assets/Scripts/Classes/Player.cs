using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Arm armLeft;
    [SerializeField]
    private Arm armRight;
    [SerializeField]
    private Rigidbody body;
    
    void Start()
    {
        GameManager.Instance.player = this;
    }

    public void GetInput(Vector2 input)
    {
        Vector3 positionChange = new Vector3(input.x, 0, input.y);
        body.velocity = positionChange * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Enemy")
        {   
            GameManager.Instance.PlayerDead();
        }
    }
}
