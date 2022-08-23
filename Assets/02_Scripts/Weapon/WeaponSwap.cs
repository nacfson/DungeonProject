using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    private Weapon _weapon;

#region 무기 SO

    public WeaponDataSO revolverSO;
    public WeaponDataSO ak47SO;
#endregion

#region 무기 오브젝트
    public GameObject revolver;
    public GameObject ak47;
#endregion
    [SerializeField]
    private WeaponAmmoSO _weaponAmmoSO;

    [SerializeField]
    private int maxWeaponCount;
    public int weaponCount;

    public List<GameObject> weaponList = new List<GameObject>();



    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
        WeaponActive();
        _weaponAmmoSO.weapon1Ammo = revolverSO.maxAmmo;
        _weaponAmmoSO.weapon2Ammo = ak47SO.maxAmmo;
    }

    public void UseAmmo()
    {
        switch(weaponCount)
        {
            case 0:
                _weaponAmmoSO.weapon1Ammo -= 1;
                break;
            case 1:
                _weaponAmmoSO.weapon2Ammo -= 1;
                break;
        }
    }

    public void ReloadWeapon()
    {
        switch(weaponCount)
        {
            case 0:
                _weaponAmmoSO.weapon1Ammo = revolverSO.maxAmmo;
                break;
            case 1:
                _weaponAmmoSO.weapon2Ammo = ak47SO.maxAmmo;
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
        }
        _weapon.SwapWeapon(weaponCount);
        WeaponActive();
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
