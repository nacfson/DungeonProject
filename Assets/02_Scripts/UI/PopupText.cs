using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupText : MonoBehaviour
{
    private TextMeshPro _textMesh;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshPro>();


    }
    public void Setup(int damageAmount, Vector3 pos, bool isCritical)
    {
        transform.position = pos;
        if (isCritical == true)
        {
            _textMesh.color = Color.red;
            _textMesh.fontSize = 10f;
            _textMesh.SetText(damageAmount *2 + "");

        }
        else
        {
            _textMesh.color = Color.white;
         _textMesh.SetText(damageAmount.ToString());

        }

        ShowingSequence();
    }

    private void ShowingSequence()
    {
        Sequence seq = DOTween.Sequence();
        Vector3 targetPosition = transform.position + new Vector3(0.5f, 0,0);
        seq.Append(transform.DOJump(targetPosition,1.5f,1,1f));
        seq.Join(_textMesh.DOFade(0, 1f));
        seq.AppendCallback(() => Destroy(gameObject));
    }

    public void Reset()
    {
        _textMesh.color = Color.white;
        _textMesh.fontSize = 7f;
    }

    private void Start()
    {
        Reset();
    }
}
