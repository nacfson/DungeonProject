using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider audioSlider;

    public void AudioControl()
    {
        float sound = audioSlider.value;
        if(sound == -40f) mixer.SetFloat("BGM",-80);
        else mixer.SetFloat("BGM",sound);
    }

}
