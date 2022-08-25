using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy1;

    [SerializeField]
    private GameObject _enemy2;

    [SerializeField]
    private MapSO _mapSO;




    public void Faze1()
    {
        StartCoroutine(SpawnEnemy1(0,3,1f));
        StartCoroutine(SpawnEnemy2(0,3,1f));
    }

    public void Faze2()
    {
        StartCoroutine(SpawnEnemy1(0,5,0.9f));
        StartCoroutine(SpawnEnemy2(0,5,0.8f));
    }
    IEnumerator SpawnEnemy1(int minCount, int maxCount, float spawnDelay)
    {
        while(minCount < maxCount)
        {
            Instantiate(_enemy1, SetSpawnPos(), Quaternion.identity);
            minCount ++;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    IEnumerator SpawnEnemy2(int minCount ,int maxCount, float spawnDelay)
    {
        while(minCount < maxCount)
        {
            SetSpawnPos();
            Instantiate(_enemy2, SetSpawnPos(), Quaternion.identity);
            minCount ++;
            yield return new WaitForSeconds(1f);
        }
    }
    private Vector3 SetSpawnPos()
    {
        Vector3 randomPos = new Vector3
        (Random.Range(_mapSO.minX,_mapSO.maxX),Random.Range(_mapSO.minY,_mapSO.maxY));
        return randomPos;
        
    }
}
