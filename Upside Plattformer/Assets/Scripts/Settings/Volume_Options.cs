using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume_Options : MonoBehaviour
{
    private AudioSource source;
    [SerializeField]
    private Slider volumeSlider;

    public void ChangeVolume()
    {
        Sound_Manager.source.volume = volumeSlider.value * volumeSlider.value;
    }
}
