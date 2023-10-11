using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Seek")]
    [SerializeField] Transform playerTransform;
    [SerializeField] float speed = 0.005f;
    [Header("Growth")]
    [SerializeField] float growthMultiplier = 1.1f;

    void FixedUpdate()
    {
        if (playerTransform != null)
        {
            Seek();
        }
    }

    void Seek()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }

    void AddSize(GameObject obj)
    {
        Vector3 maxScale = Vector3.one * growthMultiplier;
        
        if (obj.transform.localScale.x <= maxScale.x && obj.transform.localScale.y <= maxScale.y)
        {
            obj.transform.localScale *= growthMultiplier;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bacteria")
        {
            AddSize(other.gameObject);
        }
    }
}
