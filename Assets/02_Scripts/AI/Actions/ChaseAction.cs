using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    public override void TakeAction()
    {
        if (_aiActionData.isAttack == true)
        {
            _aiActionData.isAttack = false;
        }
        Vector2 direction = _brain.Target.position - transform.position;
        _aiMovementData.direction = direction.normalized;
        _aiMovementData.pointOfInterest = _brain.Target.position;
        //���� ���������� �ʴٸ� �̵� ����

        _brain.Move(direction.normalized, _brain.Target.position);
    }
}
