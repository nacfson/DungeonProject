using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : ItemAgent
{
    public override void ItemFunction()
    {
        PlayerHeartUI heartUI = gameManager.player.playerHeartUI;
        if(gameManager.player.Health < 3)
        {
            heartUI.Heal();
            StartCoroutine(gameManager.player.HealCoroutine());
            DestroyProcess();
        }
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    private void DestroyProcess()
    {
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
    }

    private void StartProcess()
    {
        spriteRenderer.enabled = true;
        collider2D.enabled = true;
    }




}
