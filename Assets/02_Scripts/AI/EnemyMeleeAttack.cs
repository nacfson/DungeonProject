using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : EnemyAttack
{
    private EnemyAIBrain _enemyAIBrain;
    private float range;
    private float distance;
    private void Start()
    {
        _enemyAIBrain = GetComponentInParent<EnemyAIBrain>();
    }

    public void CheckDistance()
    {
        range = _enemyAIBrain.Enemy.EnemyDataSO.attackDistance;
        distance = Vector2.Distance(_enemyAIBrain.transform.position, _enemyAIBrain.Target.position);
    }

    public override void Attack(int damage)
    {
        _enemyAIBrain.AIActionData.isAttack = true;
        CheckDistance();
        if (range > distance)
        {
            
        }

        StartCoroutine(WaitBeforeAttackCoroutine());
    }
}
