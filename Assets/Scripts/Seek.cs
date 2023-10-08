using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float speed = 0.005f;

    void FixedUpdate()
    {
        // CHALLENGE: This could be more efficient
        if (playerTransform != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
        // put in player's position
    }
}
