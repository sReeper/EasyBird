using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    private Transform respawnPoint;
    private Transform anchorPoint;

    private void Awake()
    {
        respawnPoint = transform.parent.Find("RespawnPoint");
        anchorPoint = transform.parent.Find("GroundSpawnAnchor");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentStatus == GameManager.Status.RUNNING)
        {
            if (transform.position.x < respawnPoint.position.x)
            {
                transform.position = new Vector2(anchorPoint.position.x, transform.position.y);
            }

            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
