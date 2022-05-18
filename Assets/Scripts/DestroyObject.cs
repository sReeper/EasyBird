using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script used to destroy the obstacles after they reach destroy zone so that the number of obstacles does not increase infinitely
public class DestroyObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles"))
        {
            if (collision.gameObject.transform.parent.gameObject != null)
            {
                Destroy(collision.gameObject.transform.parent.gameObject);
            }
        }
    }
}
