using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected float _desireAngle;
    public WeaponRenderer _weaponRenderer;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    protected virtual void Awake()
    {
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
    }
    public virtual void AimWeapon(Vector2 pointerPos)
    {
        Vector3 aimDirection = (Vector3)pointerPos - transform.position;
        _desireAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        //������
        AdjustWeaponRendering();
        transform.rotation = Quaternion.AngleAxis(_desireAngle, Vector3.forward);
    }

    private void AdjustWeaponRendering()
    {
        _weaponRenderer.FlipSprite(_desireAngle > 90f || _desireAngle < - 90f);
        _weaponRenderer.RenderBehindHead(_desireAngle > 0 && _desireAngle < 180f);
    }
    public virtual void AssignWeapon()
    {
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        //_weapon = GetComponentInChildren<Weapon>();
    }
}
