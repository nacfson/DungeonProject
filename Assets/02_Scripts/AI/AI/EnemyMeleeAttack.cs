using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : EnemyAttack
{
    public float currentDistance;
    private AIState ChaseState;
    private void Start()
    {
        ChaseState = GameObject.Find("ChaseState").GetComponent<AIState>();
    }
    public override void Attack(int damage)
    {
        if(WaitBeforeNextAttack == false)
        {
            _enemyAIBrain.AIActionData.isAttack = true;
            float distance = _enemyAIBrain.EnemyDataSo.attackDistance;
            float realDistance = Vector2.Distance(_enemyAIBrain.BasePosition.position, _enemyAIBrain.Target.position);
            currentDistance = distance - realDistance;
            if (realDistance < distance)
            {
                IHittable hit = _enemyAIBrain.Target.GetComponent<IHittable>();
                hit?.GetHit(damage,gameObject);
                Instantiate(_playerHitText,_enemyAIBrain.Target.transform);
                Debug.Log("Attack");
            }
            AttackFeedBack?.Invoke();
            StartCoroutine(WaitBeforeAttackCoroutine());

            
            _enemyAIBrain.ChangeState(ChaseState);

        }
    }
}
