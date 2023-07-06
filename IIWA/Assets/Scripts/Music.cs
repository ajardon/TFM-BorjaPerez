using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public static Music inst; 
    AudioSource _audiosource;
    public Slider sliderVolume;

    private void Awake()
    {

        if (Music.inst == null)  
        {
            Music.inst = this;
            DontDestroyOnLoad(gameObject);
            _audiosource = GetComponent<AudioSource>();
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void StopMusic()
    {
        _audiosource.volume = sliderVolume.value;
    }
}
