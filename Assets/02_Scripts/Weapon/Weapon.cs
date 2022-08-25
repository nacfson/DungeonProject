
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
public class Weapon : MonoBehaviour
{
    [SerializeField]
    private AudioSO _audioSO;
    [SerializeField]
    private WeaponAudio _weaponAudio;

    public UnityEvent OnShoot;
    [SerializeField]
    private GameObject _muzzle;
    [SerializeField]
    private GameObject _bullet;
    public WeaponSwap weaponSwap;


    [SerializeField]
    public WeaponDataSO weaponDataSO;

    [SerializeField] private GameObject _bar;

    [SerializeField] private ReloadGaugeUI _reloadGaugeUI;

    public UnityEvent OnShootNoAmmo;

    private bool _isShooting = true;


    private bool _isReloading;
    private int _maxAmmo;
    [SerializeField]
    private PanelAnimation _panelAnimation;
    [SerializeField]
    private GunPanel _gunPanel;

    [SerializeField] private float time = 1.0f;
    public int rotationValue;

    public void SwapWeapon(int weaponCount)
    {
        switch(weaponCount)
        {
            case 0:


            _weaponAudio.SetAudioClip(_audioSO.revolverShoot,_audioSO.revolverReload,_audioSO.revolverShoot);
            weaponDataSO = weaponSwap.revolverSO;
            _muzzle = weaponSwap.revolver.transform.Find("Muzzle").gameObject;
            _bullet = weaponSwap.revolver.GetComponent<WeaponBullet>().myBullet;
            _gunPanel.revolverPanel.transform.Find("GunImage").GetComponent<Image>().sprite = _gunPanel.revolverSprite;
            _gunPanel.revolverPanel.transform.Find("RemainBullet").GetComponent<TextMeshProUGUI>().text = weaponSwap.WeaponAmmo() + " / " + weaponSwap.revolverSO.maxAmmo;
            SwapProcess();

                break;
            case 1:


            _weaponAudio.SetAudioClip(_audioSO.ak47Shoot,_audioSO.ak47Reload,_audioSO.ak47Shoot);

            weaponDataSO = weaponSwap.ak47SO;
            _muzzle = weaponSwap.ak47.transform.Find("Muzzle").gameObject;
            _bullet = weaponSwap.ak47.GetComponent<WeaponBullet>().myBullet;
            _gunPanel.revolverPanel.transform.Find("GunImage").GetComponent<Image>().sprite = _gunPanel.ak47Sprite;
            _gunPanel.revolverPanel.transform.Find("RemainBullet").GetComponent<TextMeshProUGUI>().text = weaponSwap.WeaponAmmo() + " / " + weaponSwap.ak47SO.maxAmmo;
            SwapProcess();


                break;
            case 2:

            _weaponAudio.SetAudioClip(_audioSO.shotGunShoot,_audioSO.shotGunReload,_audioSO.shotGunShoot);
            weaponDataSO = weaponSwap.shotGunSO;
            _muzzle = weaponSwap.shotGun.transform.Find("Muzzle").gameObject;
            _bullet = weaponSwap.shotGun.GetComponent<WeaponBullet>().myBullet;
            _gunPanel.revolverPanel.transform.Find("GunImage").GetComponent<Image>().sprite = _gunPanel.shotGunSprite;
            _gunPanel.revolverPanel.transform.Find("RemainBullet").GetComponent<TextMeshProUGUI>().text = weaponSwap.WeaponAmmo() + " / " + weaponSwap.shotGunSO.maxAmmo;
            SwapProcess();
                break;

            default:
                Debug.LogError("SO가 존재하지 않습니다.");
                break;
        }
        

    }
    private void SwapProcess()
    {
        StopAllCoroutines();
        _reloadGaugeUI.gameObject.SetActive(false);
        _isReloading = false;
                   _gunPanel.PanelActiveTrue();
        //_panelAnimation.Animation(_gunPanel.revolverPanel);
        weaponSwap.WeaponActive();
    }


    private void Awake()
    {
        SwapWeapon(0);
        //_reloadGaugeUI = GameObject.Find("ReloadGaugeUI").GetComponent<ReloadGaugeUI>();
        //_reloadGaugeUI.gameObject.SetActive(false);
        _isReloading = false;
    }


    public void ShootBullet()
    {

        _weaponAudio.PlayShootSound();
        Vector2 pos = new Vector2(transform.position.x,transform.position.y);
        GameObject obj  = Instantiate(_bullet, pos, Quaternion.identity);
        obj.transform.rotation = transform.rotation;
        obj.transform.SetParent(null);
        
        weaponSwap.UseAmmo();


    }

    private IEnumerator Reload()
    {
        _reloadGaugeUI.gameObject.SetActive(true);
        float time = 0f;
        _weaponAudio.PlayReloadSound();
        while(time <= weaponDataSO.reloadTime)
        {
            _reloadGaugeUI.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.75f);
            _reloadGaugeUI.ReloadGageNormal(time / weaponDataSO.reloadTime);
            time += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Reloading()
    {
        StartCoroutine(Reload());
        _isReloading = true;
        yield return new WaitForSeconds(weaponDataSO.reloadTime);
        _isReloading = false;
        weaponSwap.ReloadWeapon();
        //_maxAmmo = _weaponDataSO.maxAmmo;
        _reloadGaugeUI.gameObject.SetActive(false);
            
        
    }
    private void Update()
    {
        OnShootEvent();
        if(Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            StartCoroutine(Reloading());
        }

    }

    public void OnShootEvent()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            _isShooting = true;
            if(_isShooting == true && _isReloading == false)
            {
                if(weaponSwap.WeaponAmmo() > 0 )
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


    protected void FinishShooting()
    {
        StartCoroutine(WaitShootingDelay());
        if(weaponDataSO.automaticFire == false)
        {
            _isShooting = false;
        }
    }

    public IEnumerator WaitShootingDelay()
    {
        _isReloading = true;
        yield return new WaitForSeconds(weaponDataSO.shootingDelay);
        _isReloading = false;
        
    }
}
