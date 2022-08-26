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
        //���⼭ �극���� ���ؼ� ���ݻ��� ����
        _enemyAIBrain.AIActionData.isAttack = false;
    }

    
    public void PlayAttackAnimation()
    {
        EnemyMeleeAttack ema = _enemyMeleeAttack;
        _animator.SetTrigger(_attackHash);
        transform.DOMove(new Vector3(transform.position.x + ema.currentDistance, transform.position.y + ema.currentDistance ), 0.3f);

    }

    public override void PlayDeadAnimation()
    {
        base.PlayDeadAnimation();
        _animator.SetBool(_deathBoolHash, true);
    }

    public void EndOfDeadAnimation()
    {
        _enemyAIBrain.Enemy.Die();
    }
    public void Enemy1DeadAnimation()
    {
        _enemyAIBrain.Enemy.Die();
    }
}