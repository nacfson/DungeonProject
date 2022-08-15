using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Weapon : MonoBehaviour
{

    public UnityEvent OnShoot;
    [SerializeField]
    private GameObject _muzzle;
    [SerializeField]
    private GameObject _circle;
    [SerializeField] private WeaponDataSO _weaponDataSO;

    [SerializeField] private GameObject _bar;

    [SerializeField] private ReloadGaugeUI _reloadGaugeUI;

    private bool _isReloading;
    private int _maxAmmo;
    private void Start()
    {
        _reloadGaugeUI = GetComponentInChildren<ReloadGaugeUI>();
        _reloadGaugeUI.gameObject.SetActive(false);
        _isReloading = true;
        _maxAmmo = _weaponDataSO.maxAmmo;
        StartCoroutine(WaitShootingDelay());
        StartCoroutine(Reloading());
    }


    public void ShootBullet()
    {
        GameObject obj  = Instantiate(_circle, transform.position, Quaternion.identity);
        obj.transform.rotation = transform.rotation;
        obj.transform.SetParent(null);
        _maxAmmo -= 1;
    }

    private IEnumerator Reload()
    {
        _reloadGaugeUI.gameObject.SetActive(true);
        float time = 0f;
        while(time <= _weaponDataSO.reloadTime)
        {
            _reloadGaugeUI.ReloadGageNormal(time / _weaponDataSO.reloadTime);
            time += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator Reloading()
    {
        while(true)
        {
            if(Input.GetKey(KeyCode.R))
            {
                StartCoroutine(Reload());
                yield return new WaitForSeconds(_weaponDataSO.reloadTime);
                _maxAmmo = _weaponDataSO.maxAmmo;
                _reloadGaugeUI.gameObject.SetActive(false);
            }
            yield return null;
        }
    }

    public IEnumerator WaitShootingDelay()
    {
        while(true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(_maxAmmo > 0 )
                {
                    ShootBullet();
                    yield return new WaitForSeconds(_weaponDataSO.shootingDelay);
                }

            }
            yield return null;
        }
    }
}
