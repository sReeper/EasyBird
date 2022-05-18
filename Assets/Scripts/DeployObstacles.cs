using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployObstacles : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnTime = 3f;

    private Camera mainCamera;


    void Start()
    {
        mainCamera = Camera.main;
        
        StartCoroutine(deployObstacles());
    }


    private void spawnObstacle()
    {
        // Get the location just outside of camera visibility range
        float spawnXCordinate = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, 0, mainCamera.nearClipPlane)).x + 2;
        GameObject obstacle = Instantiate(obstaclePrefab);
        obstacle.transform.position = new Vector3(spawnXCordinate, transform.position.y + Random.Range(-2f, 4.5f));
    }

    IEnumerator deployObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            if (GameManager.Instance.CurrentStatus == GameManager.Status.RUNNING)
            {
                spawnObstacle();
            }
        }
    }
}
