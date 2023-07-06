using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    public GameObject mute;

    private int effectsOn;

    public void Start()
    {
        effectsOn = 1;
        PlayerPrefs.SetInt("Effects", effectsOn);
        mute.gameObject.SetActive(false);
    }

    public void SoundEffects(bool toggleValue)
    {
        if (toggleValue == true)
        {
            effectsOn = 1;
            PlayerPrefs.SetInt("Effects", effectsOn);
            mute.gameObject.SetActive(false);
        }
        if (toggleValue == false)
        {
            effectsOn = 0;
            PlayerPrefs.SetInt("Effects", effectsOn);
            mute.gameObject.SetActive(true);
        }
    }
}
