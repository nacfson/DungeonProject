using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : EnemyAttack
{
    
    public float distance;
    public float realDistance;
    public override void Attack(int damage)
    {
        if(WaitBeforeNextAttack == false)
        {
            _enemyAIBrain.AIActionData.isAttack = true;
            distance = _enemyAIBrain.EnemyDataSo.attackDistance;
            realDistance = Vector2.Distance(_enemyAIBrain.BasePosition.position, _enemyAIBrain.Target.position);
            if (realDistance < distance)
            {
                PoolAbleMono obj = PoolManager.Instance.Pop("EnemyBullet");
                Vector2 pos = _aiMovementData.pointOfInterest - (Vector2)transform.position;
                Quaternion quaternion = Quaternion.identity;
                quaternion.eulerAngles = new Vector2(pos.x,pos.y);
                obj.transform.SetPositionAndRotation(transform.position ,quaternion);

                
                obj.transform.Rotate(0,0,(float)GameManager.VectorToDegree(_aiMovementData.pointOfInterest - (Vector2)transform.position));
                //Instantiate(_playerHitText,_enemyAIBrain.Target.transform);
            }
            AttackFeedBack?.Invoke();
            StartCoroutine(WaitBeforeAttackCoroutine());
        }
    }
}
