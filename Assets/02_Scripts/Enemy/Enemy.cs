using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : PoolAbleMono,IHittable, IAgent
{
    public EnemyDataSO EnemyDataSO
    {
        get
        {
            return _enemyDataSO;
        }
    }
    public bool IsDead
    {
        get
        {
            return _isDead;
        }
    }

    public bool IsEnemy => true;
    
    public GameManager gameManager;

    public Vector3 HitPoint {get; private set;}

    private EnemyItemDrop _enemyItemDrop;


    public int Health {get; set;}

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

    protected Collider2D _collider;
    
    private Animator _animator;
    public PopupText popupText;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _collider.enabled = true;
        _isDead = false;
        _isActive = true;
        hp = _enemyDataSO.maxHP;
        _enemyBrain = GetComponent<EnemyAIBrain>();
        _enemyAttack = GetComponent<EnemyAttack>();
        _enemyAttack.AttackDelay = _enemyDataSO.attackDelay;
        _animator = GetComponentInChildren<Animator>();
        _enemyItemDrop = GetComponent<EnemyItemDrop>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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




    public virtual void PerformAttack(int damage)
    {
        if(_isDead == false && _isActive == true)
        {
            _enemyAttack.Attack(_enemyDataSO.damage);
        }
    }

    public void Die()
    {
        _enemyBrain.gameManager.mobCount ++;
        PoolManager.Instance.Push(this);
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (_isDead == true) return;
        HitPoint = damageDealer.transform.position;
        OnGetHit?.Invoke();
        if(hp <= 0)
        {
            DeadProcess();
        }
    }
///Enemy가 죽었을때 실행되는 프로세스
    public void DeadProcess()
    {
        hp = 0;
        _isDead = true;
        _animator.SetBool("isDead",true);
        _animator.SetBool("isWalk",false);
        _collider.enabled = false;
        gameManager.Faze5?.Invoke();
    }
    public override void Init()
    {
        hp = _enemyDataSO.maxHP;
        _animator.SetBool("isDead",false);
        _animator.SetBool("isWalk",true);
        _isDead = false;
        gameObject.SetActive(true);
        _isActive = true;
        _collider.enabled = true;
    }
}
