using System.Net.Mail;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public override void TakeAction()
    {
        if(_brain.Enemy.IsDead == false)
        {
            if (_aiActionData.isAttack == true)
            {
                _aiActionData.isAttack = false;
            }
            Vector2 direction = _brain.Target.position - transform.position;
            if(_brain.Target.position.x - transform.position.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
            _aiMovementData.direction = direction.normalized;
            _aiMovementData.pointOfInterest = _brain.Target.position;
            _brain.Move(direction.normalized, _brain.Target.position);
        }
        else
        {
            _brain.Move(Vector3.zero, new Vector2(_brain.BasePosition.position.x,_brain.BasePosition.position.y));
        }

    }
}
