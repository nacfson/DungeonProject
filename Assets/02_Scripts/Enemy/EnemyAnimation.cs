using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyAnimation : AgentAnimation
{
    protected EnemyAIBrain _enemyAIBrain;

    protected EnemyMeleeAttack _enemyMeleeAttack;
    protected readonly int _attackHash = Animator.StringToHash("isAttack");
    protected readonly int _deathBoolHash = Animator.StringToHash("isDead");


    protected override void Awake()
    {
        base.Awake();
        _enemyAIBrain = GetComponentInParent<EnemyAIBrain>();
        _enemyMeleeAttack = GetComponentInParent<EnemyMeleeAttack>();

    }

    public void SetEndOffAttackAnimation()
    {
        _enemyAIBrain.AIActionData.isAttack = false;
    }

    
    public void PlayAttackAnimation()
    {
        EnemyMeleeAttack ema = _enemyMeleeAttack;
        _animator.SetBool(_attackHash, true);
    }


    public override void PlayDeadAnimation()
    {
        base.PlayDeadAnimation();
        _animator.SetBool(_deathBoolHash, true);
    }
    public void EndOfAttack()
    {
        _enemyAIBrain.Enemy.PerformAttack(_enemyAIBrain.Enemy.EnemyDataSO.damage);
        _animator.SetBool(_attackHash,false);
    }


    public void Enemy1DeadAnimation()
    {
        _enemyAIBrain.Enemy.Die();
    }



}