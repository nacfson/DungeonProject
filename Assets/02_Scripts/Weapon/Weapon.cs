using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject parentObj;
    private bool _delayCoroutine;
    [SerializeField] private WeaponDataSO _weaponDataSO;
    private void Start()
    {
        PoolManager.CreatePool<Bullet>("Circle",  this.gameObject ,30);

    }
    public void OnShoot()
    {
        
        if(_delayCoroutine == true)
        {
            Bullet bullet = PoolManager.GetItem<Bullet>("Circle");
            bullet.transform.SetParent(null);
        }
    }
    public IEnumerator WaitShootingDelay()
    {
        _delayCoroutine = true;
        yield return new WaitForSeconds(_weaponDataSO.shootingDelay);
        _delayCoroutine = false;
    }
    public void OnWaitShootingDelay()
    {
        StartCoroutine(WaitShootingDelay());
    }

}
