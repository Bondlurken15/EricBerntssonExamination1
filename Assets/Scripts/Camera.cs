using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    void FixedUpdate()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + new Vector3(0, 0, -10);
        }
    }
}
