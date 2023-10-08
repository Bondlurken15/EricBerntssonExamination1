using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Seek")]
    [SerializeField] Transform playerTransform;
    [SerializeField] float speed = 0.005f;
    [Header("Scale Wobble")]
    [SerializeField] float xWobble = 0.002f;
    [SerializeField] float yWobble = 0.002f;
    [SerializeField] float xScaleExcess = 0.1f;
    [SerializeField] float yScaleExcess = 0.1f;
    [SerializeField] float xScaleCorrection = 0.005f;
    [SerializeField] float yScaleCorrection = 0.005f;
    [Header("Position Wobble")]
    [SerializeField] float xMove = 0.02f;
    [SerializeField] float yMove = 0.02f;

    Vector3 standardLocalScale;
    Vector3 maxLocalScale;
    Vector3 minLocalScale;

    void Start()
    {
        standardLocalScale = transform.localScale;
        maxLocalScale = standardLocalScale + new Vector3(xScaleExcess, yScaleExcess, 0);
        minLocalScale = standardLocalScale - new Vector3(xScaleExcess, yScaleExcess, 0);
    }

    void FixedUpdate()
    {
        Seek();
        Wobble();
    }

    void Seek()
    {
        if (playerTransform != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }
    
    void Wobble()
    {
        transform.position = transform.position + new Vector3(Random.Range(-xMove, xMove), Random.Range(-yMove, yMove));

        if (transform.localScale.x > maxLocalScale.x)
        {
            transform.localScale = transform.localScale - new Vector3(xScaleCorrection, 0, 0);
        }
        if (transform.localScale.x < minLocalScale.x)
        {
            transform.localScale = transform.localScale + new Vector3(xScaleCorrection, 0, 0);
        }
        if (transform.localScale.y > maxLocalScale.y)
        {
            transform.localScale = transform.localScale - new Vector3(0, yScaleCorrection, 0);
        }
        if (transform.localScale.y < minLocalScale.y)
        {
            transform.localScale = transform.localScale + new Vector3(0, yScaleCorrection, 0);
        }
        else
        {
            transform.localScale = transform.localScale + new Vector3(Random.Range(-xWobble, xWobble), Random.Range(-yWobble, yWobble));
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Friendly")
        {
            print("got me");
            Destroy(other.gameObject);
            maxLocalScale += new Vector3(0.5f, 0.5f, 0);
            transform.localScale += new Vector3(.5f, .5f, 0);
        }
    }
}
