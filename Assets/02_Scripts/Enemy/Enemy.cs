using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityEvent OnDie;
    public EnemyDataSO EnemyDataSO
    {
        get
        {
            return _enemyDataSO;
        }
    }
    [SerializeField] private EnemyDataSO _enemyDataSO;
    public int hp;
    private bool _isDead;
    protected EnemyAttack _attack;
    protected EnemyMeleeAttack _meleeAttack;

    private void Awake()
    {
        hp = _enemyDataSO.maxHP;
        _meleeAttack = GetComponent<EnemyMeleeAttack>();
    }

    public void PerformAttack()
    {
        if (_isDead == false)
        {
            _attack.Attack(_enemyDataSO.damage);
        }
    }

    private void Update()
    {
        DieCheck();
    }

    private void DieCheck()
    {
        if (hp <= 0)
        {
            OnDie?.Invoke();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
