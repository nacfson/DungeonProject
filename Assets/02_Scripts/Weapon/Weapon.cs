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

    public UnityEvent OnShootNoAmmo;

    private bool _isShooting = true;


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
            case 2:
            _weaponDataSO = _weaponSwap.shotGunSO;
            _muzzle = _weaponSwap.shotGun.transform.Find("Muzzle").gameObject;
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
        StartCoroutine(Reloading());
    }


    public void ShootBullet()
    {
        for(int i= 0; i<_weaponDataSO.burstCount; i++)
        {
            Vector2 pos = new Vector2(transform.position.x,transform.position.y);
            GameObject obj  = Instantiate(_circle, pos, Quaternion.identity);
            obj.transform.rotation = transform.rotation;
            obj.transform.SetParent(null);
        }
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
            if(Input.GetKeyDown(KeyCode.R) && _isReloading == false)
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

    public void OnShootEvent()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            _isShooting = true;
            if(_isShooting == true && _isReloading == false)
            {
                if(_weaponSwap.WeaponAmmo() > 0 )
                {
                    ShootBullet();
                    OnShoot?.Invoke();
                    StartCoroutine(WaitShootingDelay());
                }
                else
                {
                    _isShooting = false;
                    OnShootNoAmmo?.Invoke();
                    return;
                }
                FinishShooting();

            }
        }
    }

    private void Update()
    {
        OnShootEvent();
    }
    protected void FinishShooting()
    {
        StartCoroutine(WaitShootingDelay());
        if(_weaponDataSO.automaticFire == false)
        {
            _isShooting = false;
        }
    }

    public IEnumerator WaitShootingDelay()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_weaponDataSO.shootingDelay);
        _isReloading = false;
        
    }
}
