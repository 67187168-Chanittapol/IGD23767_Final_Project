using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private MovingObstacle[] obstaclePrefabs;
    [SerializeField] private Vector3 spawnDirection = Vector3.right;
    [SerializeField] private float obstacleSpeed = 8f;
    [SerializeField] private float laneDistance = 40f;

    [SerializeField] private float minSpawnInterval = 1.5f;
    [SerializeField] private float maxSpawnInterval = 3.5f;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);

            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        MovingObstacle prefab = obstaclePrefabs[randomIndex];

        if (prefab != null)
        {
            MovingObstacle spawned = Instantiate(prefab, transform.position, Quaternion.identity);
            spawned.Setup(spawnDirection, obstacleSpeed, laneDistance);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.4f);
        Gizmos.DrawRay(transform.position, spawnDirection.normalized * 3f);
    }
}