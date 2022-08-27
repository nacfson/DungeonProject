using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerParent : MonoBehaviour
{
    public List<EnemySpawn> spawner = new List<EnemySpawn>();


    public void Start2Spawn()
    {
        int enemy1Count = 3;
        int enemy2Count = 2;
        float spawnDelay = 1f;
        foreach(EnemySpawn em in spawner)
        {
            em.Faze(enemy1Count,enemy2Count,spawnDelay);
        }
    }
    public void Start3Spawn()
    {
        int enemy1Count = 5;
        int enemy2Count = 3;
        float spawnDelay = 1.5f;
        foreach(EnemySpawn em in spawner)
        {
            em.Faze(enemy1Count,enemy2Count,spawnDelay);
        }
    }
    

}
