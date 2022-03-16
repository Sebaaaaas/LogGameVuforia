using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject logPrefab;
    public GameObject logWarriorPrefab;
    public float initialSpawnFreq;
    float saveSpawnFreq;

    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;

    Vector3 auxSpawnerPos;
    int r;
    // Start is called before the first frame update
    void Start()
    {
        saveSpawnFreq = initialSpawnFreq;
    }

    // Update is called once per frame
    void Update()
    {
        saveSpawnFreq -= Time.deltaTime;

        if(saveSpawnFreq <= 0.0f)
        {
            SpawnEnemy();
            saveSpawnFreq = initialSpawnFreq;
        }
    }

    void SpawnEnemy()
    {
        r = Random.Range(0, 3);

        switch (r)
        {
            case 0:
                auxSpawnerPos = spawner1.transform.position;
                break;
            case 1:
                auxSpawnerPos = spawner2.transform.position;
                break;
            case 2:
                auxSpawnerPos = spawner3.transform.position;
                break;
        }

        r = Random.Range(0, 2);

        switch (r)
        {
            case 0:
                Instantiate(logWarriorPrefab, auxSpawnerPos + new Vector3(0,logWarriorPrefab.transform.localScale.y,0), new Quaternion(0.0f, 1.0f, 0.0f, 0.0f));
                break;
            case 1:
                Instantiate(logPrefab, auxSpawnerPos, Quaternion.identity);
                break;
        }
        
    }
}
