using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BacteriaMovement : MonoBehaviour
{
    [Header("Position Wobble")]
    [SerializeField] float xMove = 0.02f;
    [SerializeField] float yMove = 0.02f;
    [Header("Scale Wobble")]
    [SerializeField] float xWobble = 0.002f;
    [SerializeField] float yWobble = 0.002f;
    [SerializeField] float xScaleExcess = 0.1f;
    [SerializeField] float yScaleExcess = 0.1f;
    [SerializeField] float xScaleCorrection = 0.005f;
    [SerializeField] float yScaleCorrection = 0.005f;

    Vector3 standardLocalScale;
    Vector3 maxLocalScale;
    Vector3 minLocalScale;
    string standardTag;

    void Start()
    {
        standardTag = tag;
        standardLocalScale = transform.localScale;
        maxLocalScale = standardLocalScale + new Vector3(xScaleExcess, yScaleExcess, 0);
        minLocalScale = standardLocalScale - new Vector3(xScaleExcess, yScaleExcess, 0);
    }

    void FixedUpdate()
    {
        if (tag != "Infected")
        {
            ScaleWobble();
        }

        MoveWobble();
    }

    void ScaleWobble()
    {
        if (transform.localScale.x > maxLocalScale.x ||
            transform.localScale.x < minLocalScale.x ||
            transform.localScale.y > maxLocalScale.y ||
            transform.localScale.y < minLocalScale.y)
        {
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
        }
        else
        {
            transform.localScale = transform.localScale + new Vector3(Random.Range(-xWobble, xWobble), Random.Range(-yWobble, yWobble));
        }
    }

    void MoveWobble()
    {
        transform.position = transform.position + new Vector3(Random.Range(-xMove, xMove), Random.Range(-yMove, yMove));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (standardTag != "Antidote" && standardTag != "Enemy")
            {
                tag = "Infected";
            }
        }
        if (other.gameObject.tag == "Antidote")
        {
            if (standardTag != "Antidote" && standardTag != "Enemy")
            {
                tag = "Bacteria";
                
            }
        }
    }
}
