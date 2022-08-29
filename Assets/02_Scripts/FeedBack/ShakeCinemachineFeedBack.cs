using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCinemachineFeedBack : FeedBack
{
    public Camera MainCam
    {
        get
        {

            _mainCam ??= GameObject.Find("Main Camera").GetComponent<Camera>();
            
            return _mainCam;
        }
    }

    public CinemachineVirtualCamera Vcam
    {
        get
        {
            _cmVcam ??= GameObject.Find("CM cam").GetComponent<CinemachineVirtualCamera>();
            return _cmVcam;
        }
    }
    private Camera _mainCam= null;
    [SerializeField] private CinemachineVirtualCamera _cmVcam;
    [SerializeField]
    [Range(0, 5f)]
    private float _amplitude = 1, _frequency = 1;
    [SerializeField]
    [Range(0, 1f)]
    private float _duration = 0.1f;

    private CinemachineBasicMultiChannelPerlin _noise;

    private void OnEnable()
    {
        _cmVcam = Define.Vcam;
        _noise = _cmVcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    public override void CompletePrevFeedBack()
    {
        StopAllCoroutines();
        _noise.m_AmplitudeGain = 0;
    }

    public override void CreateFeedBack()
    {
        _noise.m_AmplitudeGain = _amplitude;
        _noise.m_FrequencyGain = _frequency;
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        float time = _duration;
        while(time > 0)
        {
            _noise.m_AmplitudeGain = Mathf.Lerp(0, _amplitude, time / _duration);
            //Lerp(a,b,time)
            yield return null;
            time -= Time.deltaTime;
        }
        _noise.m_AmplitudeGain = 0;
    }

}
