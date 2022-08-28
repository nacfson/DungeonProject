using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    protected AIActionData _aiActionData;
    protected AIMovementData _aiMovementData;


    protected EnemyAIBrain _brain;

    protected virtual void Awake()
    {
        _brain = GetComponentInParent<EnemyAIBrain>();
        _aiActionData = GetComponentInParent<AIActionData>();
        _aiMovementData = GetComponentInParent<AIMovementData>();
        
    }

    public abstract void TakeAction();


}
