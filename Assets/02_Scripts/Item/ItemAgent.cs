using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemAgent : MonoBehaviour
{
    public GameManager gameManager;

    public SpriteRenderer spriteRenderer;

    public Collider2D collider2D;

    public abstract void ItemFunction();
    protected virtual void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ItemFunction();
        }
    }
    
}
