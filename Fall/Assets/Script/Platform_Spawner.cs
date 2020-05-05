using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Spawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;

    public float platform_Spawn_Timer = 2f;
    private float current_Platform_Spawn_Timer;

    private int platform_Spawn_Count;
    public float min_X = -9.95f, max_X = 9.95f;


    // Start is called before the first frame update
    void Start()
    {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }

// Update is called once per frame
void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        current_Platform_Spawn_Timer += Time.deltaTime;
        
        if(current_Platform_Spawn_Timer >= platform_Spawn_Timer)
        {
            platform_Spawn_Count++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);

            GameObject newPlatform = null;

            if(platform_Spawn_Count < 3)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                Debug.Log(platform_Spawn_Count);
            }
            else if(platform_Spawn_Count == 3)
            {
                if(Random.Range(0,2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                    Debug.Log(platform_Spawn_Count);
                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                    newPlatform.transform.Rotate(180, 0, 0);
                    Debug.Log(platform_Spawn_Count);
                }

                platform_Spawn_Count = 0;
                
            }

            if(newPlatform)
                newPlatform.transform.parent = transform;
            current_Platform_Spawn_Timer = 0f;


        }
    }
}
