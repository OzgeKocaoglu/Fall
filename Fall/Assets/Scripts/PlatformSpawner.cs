using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;

    public float platformSpawnTimer = 2f;
    private float currentPlatformSpawnTimer;

    private int platformSpawnCount;
    public float minX = -9.95f, maxX = 9.95f;

    void Start()
    {
        currentPlatformSpawnTimer = platformSpawnTimer;
    }

    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        currentPlatformSpawnTimer += Time.deltaTime;
        
        if(currentPlatformSpawnTimer >= platformSpawnTimer) {
            platformSpawnCount++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);

            GameObject newPlatform = null;

            if(platformSpawnCount < 3) {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                Debug.Log(platformSpawnCount);
            }
            else if(platformSpawnCount == 3) {
                if(Random.Range(0,2) > 0) {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                    Debug.Log(platformSpawnCount);
                }
                else {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                    newPlatform.transform.Rotate(180, 0, 0);
                    Debug.Log(platformSpawnCount);
                }

                platformSpawnCount = 0;
                
            }

            if (newPlatform)
                newPlatform.transform.parent = transform;

            currentPlatformSpawnTimer = 0f;
        }
    }
}
