using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GunPanel : MonoBehaviour
{

    public Sprite revolverSprite;
    public Sprite ak47Sprite;

    public Sprite shotGunSprite;
    public GameObject revolverPanel;


    public void OnEnable()
    {
        mySequence.Restart();
    }

    public void PanelActiveTrue()
    {
        revolverPanel.SetActive(true);
    }
    Sequence mySequence;

    public GameObject panel;

    public void DOTweenMove(GameObject gameObject)
    {
        mySequence = DOTween.Sequence()
        .OnStart(() => {
            transform.localScale = Vector3.zero;
            GetComponent<CanvasGroup>().alpha = 0;
        })
        .Append(transform.DOScale(1, 1).SetEase(Ease.OutBounce))
        .Join(GetComponent<CanvasGroup>().DOFade(1, 1))
        .SetDelay(0.5f);
    }


}
