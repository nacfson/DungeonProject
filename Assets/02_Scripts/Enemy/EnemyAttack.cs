using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    protected EnemyAIBrain _enemyAIBrain;

    [SerializeField] protected float _attackDelay;
    public float AttackDelay
    {
        get
        {
            return _attackDelay;
        }
        set
        {
            _attackDelay = Mathf.Clamp(value, 0.1f, 10f);
        }
    }
    protected bool _waitBeforeNextAttack;
    private void Awake()
    {
        _enemyAIBrain = GetComponentInParent<EnemyAIBrain>();
    }

    public abstract void Attack(int damage);

    protected IEnumerator WaitBeforeAttackCoroutine()
    {
        _waitBeforeNextAttack = true;
        yield return new WaitForSeconds(AttackDelay);
        _waitBeforeNextAttack = false;
    }
}
