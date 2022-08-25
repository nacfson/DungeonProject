using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Weapon/Bullet")]
public class WeaponDataSO : ScriptableObject
{
    public int damage;
    public float reloadTime;
    public float shootingDelay;
    public float bandongRange;
    public int speed;

    public int maxAmmo;

    public int burstCount;

    public bool automaticFire;

    public Sprite sprite;

}
