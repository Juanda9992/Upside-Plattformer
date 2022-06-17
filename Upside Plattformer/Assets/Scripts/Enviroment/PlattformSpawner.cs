using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject plattformPrefab;
    public float timeBetweenSpawn;
    private float currentTimeBetweenSpawn;
    private float minX = 2,maxX = -2f,currentX;


    // Start is called before the first frame update
    void Start()
    {
        currentTimeBetweenSpawn = 1.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Scene_Loader.hasLosed)
        {
            if(currentTimeBetweenSpawn > 0)
            {
                currentTimeBetweenSpawn-=Time.deltaTime;
            }
            else
            {
                currentTimeBetweenSpawn = timeBetweenSpawn;
                SpawnPlatform();
            }
        }

    }

    private void SpawnPlatform()
    {
        currentX = Random.Range(minX,maxX);
        Instantiate(plattformPrefab,new Vector2(transform.position.x - currentX, transform.position.y),Quaternion.identity);
    }

    private void ResetTimer()
    {
        currentTimeBetweenSpawn = 1.9f;
        timeBetweenSpawn = 0.9f;
    }

    private void IncreaseDifficult()
    {
        timeBetweenSpawn -= 0.06f;
    }

    private void OnEnable() 
    {
        Scene_Loader.onRestarted += ResetTimer;    
        GyroTest.onReachedGoal += IncreaseDifficult;
    }

    void OnDisable()
    {
        Scene_Loader.onRestarted -= ResetTimer;
    }




}
