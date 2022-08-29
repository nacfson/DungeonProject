using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private Collider2D _collider2D;
    public Enemy enemy;
    


    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private float RandomCritical()
    {
        float criticalRange;
        criticalRange = UnityEngine.Random.Range(0f,10f);
        return criticalRange;
    }    
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Bullet":
                BulletCheck(col);
                StartCoroutine(ChangeColorCoroutine());
                break;
            case "ShotGunBullet":
                ShotGunBulletCheck(col);
                StartCoroutine(ChangeColorCoroutine());
                break;


        }
    }

    IEnumerator ChangeColorCoroutine()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
    private void BulletCheck(Collider2D col)
    {
        bool _isCritical;
        if(RandomCritical() > 7f)
        {
            _isCritical = true;
        }
        else
        {
            _isCritical = false;
        }
        
        Bullet bul = col.gameObject.GetComponent<Bullet>();
        if(_isCritical == true)
        {
            enemy.hp -= bul.BulletDataSO.damage * 2;
        }
        else
        {
            enemy.hp -= bul.BulletDataSO.damage;
        }
        enemy.GetHit(bul.BulletDataSO.damage,gameObject);
        PopupText popupText = enemy.popupText.GetComponent<PopupText>();
        PopupText obj = Instantiate(popupText) as PopupText;
        obj?.Setup(bul.BulletDataSO.damage,transform.position
         + new Vector3(0,0.3f), _isCritical);
    }
    private void ShotGunBulletCheck(Collider2D col)
    {
        bool _isCritical;
        if(RandomCritical() > 7f)
        {
            _isCritical = true;
        }
        else
        {
            _isCritical = false;
        }
        
        ShotGunBullet bul = col.gameObject.GetComponent<ShotGunBullet>();
        if(_isCritical == true)
        {
            enemy.hp -= bul.BulletDataSO.damage * 2;
        }
        else
        {
            enemy.hp -= bul.BulletDataSO.damage;
        }
        enemy.GetHit(bul.BulletDataSO.damage,gameObject);
        PopupText popupText = enemy.popupText.GetComponent<PopupText>();
        PopupText obj = Instantiate(popupText) as PopupText;
        obj?.Setup(bul.BulletDataSO.damage,transform.position
         + new Vector3(0,0.3f), _isCritical);
    }
}
