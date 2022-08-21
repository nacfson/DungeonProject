using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour,IHittable, IAgent
{
    public EnemyDataSO EnemyDataSO
    {
        get
        {
            return _enemyDataSO;
        }
    }

    public bool IsEnemy => true;

    public Vector3 HitPoint {get; private set;}

    public int Health {get; private set;}

    [field:SerializeField]
    public UnityEvent OnDie {get; set;}
    [field:SerializeField]

    public UnityEvent OnGetHit {get; set;}

    [SerializeField] private EnemyDataSO _enemyDataSO;
    public int hp;
    protected bool _isDead = false;

    protected bool _isActive;
    protected EnemyAIBrain _enemyBrain;
    protected EnemyAttack _enemyAttack;

    private void Awake()
    {
        hp = _enemyDataSO.maxHP;
        _enemyBrain = GetComponent<EnemyAIBrain>();
        _enemyAttack = GetComponent<EnemyAttack>();
        _enemyAttack.AttackDelay = _enemyDataSO.attackDelay;
    }

    public void PerformAttack()
    {
        if (_isDead == false)
        {
        }
    }
    private void SetEnemyData()
    {
                _enemyAttack.AttackDelay = _enemyDataSO.attackDelay; //?????????? ????

        transform.Find("AI/IdleState/TranChase")
            .GetComponent<DecisionInner>().Distance = _enemyDataSO.viewDistance;
        transform.Find("AI/ChaseState/TranIdle")
            .GetComponent<DecisionInner>().Distance = _enemyDataSO.viewDistance;

        transform.Find("AI/ChaseState/TranAttack")
            .GetComponent<DecisionInner>().Distance = _enemyDataSO.attackDistance;
        transform.Find("AI/AttackState/TranChase")
            .GetComponent<DecisionOuter>().Distance = _enemyDataSO.attackDistance;

        Health = _enemyDataSO.maxHP;
    }

    private void Update()
    {
        DieCheck();
    }

    private void DieCheck()
    {
        if (hp <= 0)
        {
            OnDie?.Invoke();
        }
    }
    public virtual void PerformAttack(int damage)
    {
        if(_isDead == false && _isActive == true)
        {
            _enemyAttack.Attack(_enemyDataSO.damage);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if(_isDead == false) return;
        Health -= damage;
        HitPoint = damageDealer.transform.position;

        if(Health<=0)
        {
            DeadProcess();
        }
    }

    private void DeadProcess()
    {
        Health = 0;
        _isDead = true;
    }
}
