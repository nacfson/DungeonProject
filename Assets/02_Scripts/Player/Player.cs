using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IHittable, IAgent
{
    #region ü�� ���� �κ�
    [SerializeField]
    private int _maxHealth;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Clamp(value, 0,_maxHealth);
        }
    }
    [SerializeField]
    private int _health;
    #endregion

    public bool IsEnemy => false;

    
    public PlayerHeartUI playerHeartUI;

    [field : SerializeField] public UnityEvent OnDie { get; set; }
    [field : SerializeField] public UnityEvent OnGetHit { get; set; }
    [field : SerializeField] public UnityEvent<int> OnUpdateHealthUI { get; set; }
    

    public Vector3 HitPoint { get; private set; }
    private bool _isDead = false;
    private AgentMovement _agentMovement;
    public SpriteRenderer spriteRenderer;
    private void Awake()
    {
        _agentMovement = GetComponent<AgentMovement>();
        Health = _maxHealth;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (_isDead) return;
        Health -= damage;
        StartCoroutine(ChangeColorCoroutine());
        playerHeartUI.GetDamage(damage);
        if(Health <= 0)
        {
            OnDie?.Invoke();
            _isDead = true;
        }
    }
    IEnumerator ChangeColorCoroutine()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
    public IEnumerator HealCoroutine()
    {
        spriteRenderer.color = Color.green;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = Color.white;
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>

}
