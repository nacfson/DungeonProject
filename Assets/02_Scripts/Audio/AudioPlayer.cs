using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{

    protected AudioSource _audioSource;
    [SerializeField]
    protected AudioMixer _audioMixer;
    [SerializeField]
    protected float _pitchRandomness = 0.2f;

    private Slider _slider;

    protected float _basePitch;

    protected virtual void Awake()
    {
        _audioSource = GetComponent<AudioSource>();


    }

    protected virtual void Start()
    {
        _basePitch = _audioSource.pitch;
    }

    protected void PlayClipWithVariablePitch(AudioClip clip)
    {
        float randomPitch = Random.Range(-_pitchRandomness, +_pitchRandomness);
        _audioSource.pitch = _basePitch + randomPitch;
        PlayClip(clip);
    }

    protected void PlayClip(AudioClip clip)
    {

        _audioSource.Stop();
        //_audioSource.volume = GetMasterLevel();
        _audioSource.clip = clip;
        _audioSource.Play();
    }
    public float GetMasterLevel()
    {
        float sound;
        bool result = _audioMixer.GetFloat("FX", out sound);
        if(result){
            return sound;
        }else{
            return 0f;
        }
    }
}
