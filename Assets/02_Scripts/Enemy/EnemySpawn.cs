using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class EnemySpawn : PoolAbleMono
{
    [SerializeField]
    private GameObject _enemy1;

    [SerializeField]
    private GameObject _enemy2;

    [SerializeField]
    private MapSO _mapSO;




    private void Start()
    {
        Faze(3,2,1f);
    }



    public void Faze(int maxCount, int maxCount2, float spawnDelay)
    {
        StartCoroutine(SpawnEnemy1(0,maxCount,spawnDelay));
        StartCoroutine(SpawnEnemy2(0,maxCount2,spawnDelay));
    }
    public void Faze2(int maxCount,int maxCount2, int enemy3Count, float spawnDelay)
    {
        StartCoroutine(SpawnEnemy1(0,maxCount,spawnDelay));
        StartCoroutine(SpawnEnemy2(0,maxCount2,spawnDelay));
        StartCoroutine(SpawnEnemy3(0,enemy3Count,spawnDelay));
    }

    IEnumerator SpawnEnemy1(int minCount, int maxCount, float spawnDelay)
    {
        while(minCount < maxCount)
        {
            Enemy enemy = PoolManager.Instance.Pop("Enemy1")as Enemy;
            enemy.transform.SetPositionAndRotation(SetSpawnPos(), Quaternion.identity);
            minCount ++;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    IEnumerator SpawnEnemy2(int minCount ,int maxCount, float spawnDelay)
    {
        while(minCount < maxCount)
        {
            Enemy enemy2 = PoolManager.Instance.Pop("Enemy2")as Enemy;
            enemy2.transform.SetPositionAndRotation(SetSpawnPos(), Quaternion.identity);
            minCount ++;
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator SpawnEnemy3(int minCount ,int maxCount, float spawnDelay)
    {
        while(minCount < maxCount)
        {
            Enemy enemy3 = PoolManager.Instance.Pop("Enemy3")as Enemy;
            enemy3.transform.SetPositionAndRotation(SetSpawnPos(), Quaternion.identity);
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

    public override void Init()
    {
        throw new System.NotImplementedException();
    }
}
