using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WeaponSwap : MonoBehaviour
{
    private Weapon _weapon;

#region 무기 SO

    public WeaponDataSO revolverSO;
    public WeaponDataSO ak47SO;
    public WeaponDataSO shotGunSO;
#endregion

#region 무기 오브젝트
    public GameObject revolver;
    public GameObject ak47;

    public GameObject shotGun;
#endregion
    [SerializeField]
    private WeaponAmmoSO _weaponAmmoSO;

    
    public WeaponPanelSO weaponPanelSO;



    [SerializeField]
    private int maxWeaponCount;
    public int weaponCount;

    private FlashLightFeedBack _flashLightFeedBack;

    public List<GameObject> weaponList = new List<GameObject>();




    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
        WeaponActive();
        _weaponAmmoSO.weapon1Ammo = revolverSO.maxAmmo;
        _weaponAmmoSO.weapon2Ammo = ak47SO.maxAmmo;
        _weaponAmmoSO.weapon3Ammo = shotGunSO.maxAmmo;
        _flashLightFeedBack = GetComponentInChildren<FlashLightFeedBack>();
    }

    public string BulletCheck()
    {
        string bulletName = null;
        switch(weaponCount)
        {
            case 0:
                bulletName = "Bullet";
                break;
            case 1:
                bulletName = "AK47Bullet";

                break;
            case 2:
                bulletName = "ShotGunBullet";

                break;

        }
        return bulletName;
    }
    public void UseAmmo()
    {
        switch(weaponCount)
        {
            case 0:
                _weaponAmmoSO.weapon1Ammo -= 1;
                _weapon.SwapWeapon(weaponCount);
                break;
            case 1:
                _weaponAmmoSO.weapon2Ammo -= 1;
                _weapon.SwapWeapon(weaponCount);

                break;
            case 2:
                _weaponAmmoSO.weapon3Ammo -=1;
                _weapon.SwapWeapon(weaponCount);

                break;
        }
    }

    public void ReloadWeapon()
    {
        switch(weaponCount)
        {
            case 0:
                _weaponAmmoSO.weapon1Ammo = revolverSO.maxAmmo;
                _weapon.SwapWeapon(weaponCount);
                break;
            case 1:
                _weaponAmmoSO.weapon2Ammo = ak47SO.maxAmmo;
                _weapon.SwapWeapon(weaponCount);

                break;
            case 2:
                _weaponAmmoSO.weapon3Ammo = shotGunSO.maxAmmo;
                _weapon.SwapWeapon(weaponCount);
                break;


        }
    }

    public int WeaponAmmo()
    {
        int returnValue = 0;
        switch(weaponCount)
        {
            case 0:
            returnValue = _weaponAmmoSO.weapon1Ammo;
                break;
            case 1:
            returnValue = _weaponAmmoSO.weapon2Ammo;
                break;
            case 2:
            returnValue = _weaponAmmoSO.weapon3Ammo;
            break;

        }
        return returnValue;
    }

    public void ChangeWeaponCount()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(weaponCount >= maxWeaponCount - 1)
            {
                weaponCount = 0;
            }
            else
            {
                weaponCount++;
            }
            _weapon.SwapWeapon(weaponCount);
            WeaponActive();
            _flashLightFeedBack.lightTarget = weaponList[weaponCount].gameObject.transform.Find("Muzzle").GetComponent<Light2D>();
        }

    }

    private void Update()
    {
        ChangeWeaponCount();
    }

    public void WeaponActive()
    {
        for(int i =0 ; i< weaponList.Count; i++)
        {
            if(i == weaponCount)
            {
                weaponList[i].gameObject.SetActive(true);
            }
            else
            {
                weaponList[i].gameObject.SetActive(false);
            }
        }
    }
}
