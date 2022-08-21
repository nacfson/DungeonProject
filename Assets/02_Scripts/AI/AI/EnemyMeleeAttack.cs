using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : EnemyAttack
{
    public float currentDistance;
    public override void Attack(int damage)
    {
        float distance = _enemyAIBrain.EnemyDataSo.attackDistance;
        float realDistance = Vector2.Distance(_enemyAIBrain.BasePosition.position, _enemyAIBrain.Target.position);
        currentDistance = distance - realDistance;
        if (realDistance < distance)
        {
            
        }
        StartCoroutine(WaitBeforeAttackCoroutine());
    }
}
