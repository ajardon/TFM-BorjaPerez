using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Slider musicSlider;
    public Text percentageText;

    private double percentage;
    private string percent;
    void Start()
    {
        percentageText.text = "0%";

    }

    public void Volume()
    {
        percentage = ((musicSlider.value * 100) / 1);
        percent = percentage.ToString("0");
        percentageText.text = percent + "%";
    }
}
