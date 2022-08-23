using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class FlashLightFeedBack : FeedBack
{
    
    public Light2D lightTarget = null;
    [SerializeField]
    private float _lightOnDelay = 0.01f, _lightOffDelay = 0.01f;
    [SerializeField]
    private bool _defaultState = false;
    private WeaponSwap _weaponSwap;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>


    public override void CompletePrevFeedBack()
    {
        StopAllCoroutines(); // ��� �ڷ�ƾ ����
        //���� Mono �� ���� �ִ� �ڷ�ƾ�� ����
        lightTarget.enabled = _defaultState;
    }
    IEnumerator ToggleLightCo(float time, bool result, Action Callback = null)
    {
        yield return new WaitForSeconds(time);
        lightTarget.enabled = result;
        Callback?.Invoke();
    }

    public override void CreateFeedBack()
    {
        StartCoroutine(ToggleLightCo(_lightOnDelay, true, () => {
            StartCoroutine(ToggleLightCo(_lightOffDelay, false)); }));
    }
}
