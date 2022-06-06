using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject plattformPrefab;
    [SerializeField]
    private float timeBetweenSpawn;
    private float currentTimeBetweenSpawn;
    private float minX = 2,maxX = -2f,currentX;


    // Start is called before the first frame update
    void Start()
    {
        currentTimeBetweenSpawn = 2.1f;
    }

    // Update is called once per frame
    void Update()
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

    private void SpawnPlatform()
    {
        currentX = Random.Range(minX,maxX);
        Instantiate(plattformPrefab,new Vector2(transform.position.x - currentX, transform.position.y),Quaternion.identity);
    }
}
