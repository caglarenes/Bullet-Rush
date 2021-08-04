using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    Vector3 offset;

    void Update()
    {
        FollowCharacter();
    }

    void FollowCharacter()
    {
        transform.position = GameManager.Instance.player.gameObject.transform.position + offset;
    }
}
