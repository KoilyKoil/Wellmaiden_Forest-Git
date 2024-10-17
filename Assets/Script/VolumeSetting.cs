using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;

    public void AudioControl()
    {
        float sound=audioSlider.value;

        if(sound==-40f)
            masterMixer.SetFloat("MasterVolume", -80);
        else
            masterMixer.SetFloat("MasterVolume", sound);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume=AudioListener.volume==0?1:0;
    }
}
