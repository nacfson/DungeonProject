using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAIBrain : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementKeyPress;
    public UnityEvent AttackEvent;
    
    public Enemy Enemy
    {
        get
        {
            return _enemy;
        }
    }

    public Transform Target
    {
        get
        {
            return _target;
        }
    }
    protected Enemy _enemy;
    protected Transform _target;
    private Transform _basePosition;
    private AIState _currentState;
    protected AIActionData _aiActionData;

    public AIActionData AIActionData
    {
        get
        {
            return _aiActionData;
        }
        set
        {
            _aiActionData = value;
        }
    }

    public Transform BasePosition
    {
        get
        {
            return _basePosition;
        }
    }
    private void Awake()
    {
        _enemy = GetComponentInChildren<Enemy>();
        _basePosition = transform.Find("BasePosition");
    }
    public void Move(Vector2 direction, Vector2 targetPos)
    {
        OnMovementKeyPress?.Invoke(direction);
    }
    public void ChangeState(AIState state)
    {
        _currentState = state;
    }

    public virtual void Attack()
    {
        AttackEvent?.Invoke();
    }
}
