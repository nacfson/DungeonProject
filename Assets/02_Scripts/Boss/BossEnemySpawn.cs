using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class BossEnemySpawn : PoolAbleMono
{




    IEnumerator BossPattern()
    {
        while(true)
        {
            Faze(2,1,1f);
            yield return new WaitForSeconds(10f);
        }
    }
    private void Awake() 
    {
        StartCoroutine(BossPattern());
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
            enemy.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            minCount ++;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    IEnumerator SpawnEnemy2(int minCount ,int maxCount, float spawnDelay)
    {
        while(minCount < maxCount)
        {
            Enemy enemy2 = PoolManager.Instance.Pop("Enemy2")as Enemy;
            enemy2.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            minCount ++;
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator SpawnEnemy3(int minCount ,int maxCount, float spawnDelay)
    {
        while(minCount < maxCount)
        {
            Enemy enemy3 = PoolManager.Instance.Pop("Enemy3")as Enemy;
            enemy3.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            minCount ++;
            yield return new WaitForSeconds(1f);
        }
    }




    public override void Init()
    {
        throw new System.NotImplementedException();
    }
}
