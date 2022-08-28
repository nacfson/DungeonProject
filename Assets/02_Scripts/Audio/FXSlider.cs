using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class FXSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider audioSlider;

    public void AudioControl()
    {
        float sound = audioSlider.value;
        if(sound == -40f) mixer.SetFloat("FX",-80);
        else mixer.SetFloat("FX",sound);
    }
}
