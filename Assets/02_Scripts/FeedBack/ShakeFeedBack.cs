using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeFeedBack : FeedBack
{
    [SerializeField]
    private Transform _objectToShake;
    [SerializeField]
    private float _duration = 0.2f, _strength = 1f, _randomness = 90;

    [SerializeField]
    private int _vibrato = 10; //frequency
    [SerializeField]
    private bool _snapping = false, _fadeOut = false;

    public override void CompletePrevFeedBack()
    {
        _objectToShake.DOComplete();
        //��� Ʈ���� ���� �Ϸ�� Ʈ�� ������ ��ȯ;
    }

    public override void CreateFeedBack()
    {
        CompletePrevFeedBack();
        _objectToShake.DOShakePosition(_duration,_strength,_vibrato,_randomness,_snapping,_fadeOut);
    }
}
