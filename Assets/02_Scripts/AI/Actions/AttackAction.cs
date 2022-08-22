using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AIAction
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
            _brain.Move(_aiMovementData.direction,_aiMovementData.pointOfInterest);

        }
        }
    }
}
