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
    [SerializeField]
    private WeaponSwap _weaponSwap;

    [SerializeField]
    private WeaponDataSO _weaponDataSO;

    [SerializeField] private GameObject _bar;

    [SerializeField] private ReloadGaugeUI _reloadGaugeUI;


    private bool _isReloading;
    private int _maxAmmo;

    public void SwapWeapon(int weaponCount)
    {
        switch(weaponCount)
        {
            case 0:
            _weaponDataSO = _weaponSwap.revolverSO;
            _muzzle = _weaponSwap.revolver.transform.Find("Muzzle").gameObject;
            _weaponSwap.WeaponActive();

                break;
            case 1:
            _weaponDataSO = _weaponSwap.ak47SO;
            _muzzle = _weaponSwap.ak47.transform.Find("Muzzle").gameObject;
            _weaponSwap.WeaponActive();

                break;
            default:
                Debug.LogError("SO가 존재하지 않습니다.");
                break;
        }
    }


    private void Start()
    {
        SwapWeapon(1);
        _reloadGaugeUI = GameObject.Find("ReloadGaugeUI").GetComponent<ReloadGaugeUI>();
        _reloadGaugeUI.gameObject.SetActive(false);
        _isReloading = false;
        StartCoroutine(WaitShootingDelay());
        StartCoroutine(Reloading());
    }


    public void ShootBullet()
    {
        GameObject obj  = Instantiate(_circle, transform.position, Quaternion.identity);
        obj.transform.rotation = transform.rotation;
        obj.transform.SetParent(null);
        _weaponSwap.UseAmmo();
    }

    private IEnumerator Reload()
    {
        _reloadGaugeUI.gameObject.SetActive(true);
        float time = 0f;
        while(time <= _weaponDataSO.reloadTime)
        {
            _reloadGaugeUI.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.75f);
            _reloadGaugeUI.ReloadGageNormal(time / _weaponDataSO.reloadTime);
            time += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Reloading()
    {
        while(true)
        {
            if(Input.GetKey(KeyCode.R) && _isReloading == false)
            {
                StartCoroutine(Reload());
                _isReloading = true;
                yield return new WaitForSeconds(_weaponDataSO.reloadTime);
                _isReloading = false;
                _weaponSwap.ReloadWeapon();
                //_maxAmmo = _weaponDataSO.maxAmmo;
                _reloadGaugeUI.gameObject.SetActive(false);
            }
            yield return null;
        }
    }

    IEnumerator WaitShootingDelay()
    {
        while(true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(_weaponSwap.WeaponAmmo() > 0 && _isReloading == false)
                {
                    ShootBullet();
                    yield return new WaitForSeconds(_weaponDataSO.shootingDelay);
                }

            }
            yield return null;
        }
    }
}
