using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] private WeaponDataSO _bulletDataSO;
    private Rigidbody2D _rigidBody;

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(transform.position + _bulletDataSO.speed * Time.fixedDeltaTime * transform.right);
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
}
