using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletSpawn : MonoBehaviour
{
    private Enemy _enemy;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
        StartCoroutine(BossBulletCor());
    }
    IEnumerator BossBulletCor()
    {
        while(true)
        {
            yield return new WaitForSeconds(7f);
            //if(_enemy.hp<=0 ) StopAllCoroutines();
            for(int i= 0; i <18; i++)
            {
                PoolAbleMono obj = PoolManager.Instance.Pop("EnemyBullet") as PoolAbleMono;
                obj.transform.position = _enemy.gameObject.transform.position;
                obj.transform.rotation = Quaternion.Euler(0,0,i*20);
                obj.transform.SetParent(null);
            }
            yield return null;
        }
    }
    
}
