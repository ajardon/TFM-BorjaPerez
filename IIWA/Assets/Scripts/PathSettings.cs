using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PathSettings : MonoBehaviour
{
    public GameObject slider;
    public GameObject gameMode;

    public Slider slopeSlider;

    public Text slopeText;

    void Start()
    {
        slider.gameObject.SetActive(false);
        gameMode.gameObject.SetActive(false);
        slopeText.text = ("Vertical");
        slopeSlider.value = 0;
        PlayerPrefs.SetFloat("Slope", slopeSlider.value);

    }

    public void ActivateSlider()
    {
        slider.gameObject.SetActive(true);
    }

    public void ActivateGameMode()
    {
        gameMode.gameObject.SetActive(true);
    }

    public void SliderValue()
    {
        string slope;

        PlayerPrefs.SetFloat("Slope", slopeSlider.value);

        if (slopeSlider.value == 0)
        {
            slope = ("Vertical");
            slopeText.text = slope;
        }
        if (slopeSlider.value == 1)
        {
            slope = ("45º");
            slopeText.text = slope;
        }
        if (slopeSlider.value == 2)
        {
            slope = ("Horizontal");
            slopeText.text = slope;
        }
    }
}
