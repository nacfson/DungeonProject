using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy1;

    [SerializeField]
    private MapSO _mapSO;
    
    int minCount;
    int maxCount;

    float spawnDelay;

    Vector3 _randomSpawnPos;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        minCount = 0;
        maxCount = 3;
        spawnDelay = 1f;
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnEnemy());
        }
    }
    IEnumerator SpawnEnemy()
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
    private void SetSpawnPos()
    {
        _randomSpawnPos = new Vector3
        (Random.Range(_mapSO.minX,_mapSO.maxX),Random.Range(_mapSO.minY,_mapSO.maxY));
    }
}
