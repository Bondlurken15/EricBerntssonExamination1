using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);

        transform.Translate(movementDirection * speed * Time.deltaTime, 0);

        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
        transform.rotation = toRotation;
    }
}
