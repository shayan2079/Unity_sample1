using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclesType;
    [SerializeField] float positionToSpawn = 250f;
    [SerializeField] float initialSpawnPosition = 50f;
    [SerializeField] float initialObstaclesDistance = 37f;
    [SerializeField] int initialObstaclesCount = 5;

    GameObject[] obstacles = new GameObject[15];
    GameObject lastSpawnedObstacle = null;

    void Start()
    {
        CreateObstacles();
        SpawnInitialObstacles();
        StartCoroutine(ChooseObstacleToSpawn());
    }

    void CreateObstacles()
    {
        System.Random random = new();
        for (int i = 0; i < obstacles.Length; i++)
        {
            var idx = random.Next(0, obstaclesType.Length);
            obstacles[i] = Instantiate(obstaclesType[idx], new Vector3(0, 0, 0), Quaternion.identity);
            obstacles[i].SetActive(false);
            obstacles[i].transform.SetParent(transform);
        }
    }

    void SpawnInitialObstacles()
    {
        for (int i = 0; i < initialObstaclesCount; i++)
        {
            SpawnObstacle(obstacles[i], initialSpawnPosition + i * initialObstaclesDistance);
        }
    }

    IEnumerator ChooseObstacleToSpawn()
    {
        while (true)
        {
            if (positionToSpawn - lastSpawnedObstacle.transform.position.z > initialObstaclesDistance)
            {

                List<GameObject> disabledObstacles = new();
                for (int i = 0; i < obstacles.Length; i++)
                {
                    if (!obstacles[i].activeSelf)
                    {
                        disabledObstacles.Add(obstacles[i]);
                    }
                }

                System.Random random = new();
                var idx = random.Next(0, disabledObstacles.Count);
                SpawnObstacle(disabledObstacles[idx], positionToSpawn);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    void SpawnObstacle(GameObject obstacleToSpawn, float spawnPosition)
    {
        var positionOffset = Random.Range(-7.0f, 7.0f);
        obstacleToSpawn.transform.position = new Vector3(0, 0, spawnPosition + positionOffset);
        obstacleToSpawn.transform.position = new Vector3(0, 0, spawnPosition);
        obstacleToSpawn.SetActive(true);
        obstacleToSpawn.transform.SetParent(transform);
        lastSpawnedObstacle = obstacleToSpawn;
    }
}
