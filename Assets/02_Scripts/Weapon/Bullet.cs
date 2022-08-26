using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : PoolAbleMono
{
    public WeaponDataSO BulletDataSO
    {
        get
        {
            return _bulletDataSO;
        }
    }
    [SerializeField] private WeaponDataSO _bulletDataSO;
    private Rigidbody2D _rigidBody;

    private float _destroyTime = 2f;
    private void FixedUpdate()
    {
        _rigidBody.MovePosition(transform.position + _bulletDataSO.speed * Time.fixedDeltaTime *transform.right);
    }
    public override void Init()
    {

    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyObject());
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(_destroyTime);
        PoolManager.Instance.Push(this);
    }
}
