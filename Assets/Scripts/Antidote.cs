using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Antidote : MonoBehaviour
{
    [SerializeField] float shrinkMultiplier = 0.8f;
    [SerializeField] float speed;

    void RemoveSize(GameObject obj)
    {
        Vector3 standardScale = Vector3.one;

        if (obj.transform.localScale.x > standardScale.x && obj.transform.localScale.y > standardScale.y)
        {
            obj.transform.localScale *= shrinkMultiplier;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bacteria" || other.gameObject.tag == "Infected")
        {
            RemoveSize(other.gameObject);
        }
    }
}
