using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBullet : PoolAbleMono
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
        _rigidBody.MovePosition(transform.position + _bulletDataSO.speed * Time.fixedDeltaTime * transform.right);
    }
    public override void Init()
    {
        PushObject();
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(_destroyTime);
        PoolManager.Instance.Push(this);
    }
    public void PushObject()
    {
        StartCoroutine(DestroyObject());
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().GetHit(1,gameObject);
            PoolManager.Instance.Push(this);
        }
    }
}
