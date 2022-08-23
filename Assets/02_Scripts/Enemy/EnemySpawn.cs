using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy1;

    [SerializeField]
    private GameObject _enemy2;

    [SerializeField]
    private MapSO _mapSO;
    
    int minCount;
    int maxCount;

    float spawnDelay;

    Vector3 _randomSpawnPos;

    private void Awake()
    {
        minCount = 0;
        maxCount = 3;
        spawnDelay = 1f;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy2());
        StartCoroutine(SpawnEnemy1());

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnEnemy2());
        }
    }
    IEnumerator SpawnEnemy1()
    {
        minCount = 0;
        while(minCount < maxCount)
        {
            SetSpawnPos();
            Instantiate(_enemy1, _randomSpawnPos, Quaternion.identity);
            minCount ++;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    IEnumerator SpawnEnemy2()
    {
        int minCount = 0;
        int maxCount  = 1;
        while(minCount < maxCount)
        {
            SetSpawnPos();
            Instantiate(_enemy2, _randomSpawnPos, Quaternion.identity);
            minCount ++;
            yield return new WaitForSeconds(1f);
        }
    }
    private void SetSpawnPos()
    {
        _randomSpawnPos = new Vector3
        (Random.Range(_mapSO.minX,_mapSO.maxX),Random.Range(_mapSO.minY,_mapSO.maxY));
    }
}
