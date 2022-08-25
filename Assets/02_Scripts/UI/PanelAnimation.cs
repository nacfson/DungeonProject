using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utill;

public class PanelAnimation : MonoBehaviour
{
    private Sequence mySequence;

    public void Animation(GameObject gameObject)
    {
        mySequence ??= Dotween.PopUpAnimation(gameObject); 

        mySequence.Restart();
    }
}
