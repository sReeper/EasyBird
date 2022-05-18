using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentStatus == GameManager.Status.RUNNING)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
