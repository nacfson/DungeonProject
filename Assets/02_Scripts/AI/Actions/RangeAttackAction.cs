using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackAction : AIAction
{
    private EnemyAttack _enemyAttack;
    public override void TakeAction()
    {
        if(_brain.Enemy.IsDead == false)
        {
            _aiMovementData.direction = Vector2.zero;
            if (_aiActionData.isAttack == false)
            {
                _brain.Attack();
                _aiMovementData.pointOfInterest = _brain.Target.position;
                PoolAbleMono obj = PoolManager.Instance.Pop("EnemyBullet");
                obj.transform.position = transform.position;
                obj.transform.Rotate(0,0,(float)GameManager.VectorToDegree(_aiMovementData.pointOfInterest - new Vector2(transform.position.x,transform.position.y)));
                _brain.Move(_aiMovementData.direction,_aiMovementData.pointOfInterest);

            }
        }
    }
}
