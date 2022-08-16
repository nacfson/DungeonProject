using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private Collider2D _collider2D;
    public Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Bullet":
                Bullet bul = col.gameObject.GetComponent<Bullet>();
                enemy.hp -= bul.BulletDataSO.damage;
                Debug.Log("check");
                col.gameObject.SetActive(false);
                break;
        }
    }
}
