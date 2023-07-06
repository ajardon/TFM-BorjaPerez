using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WidthDropdown : MonoBehaviour
{
    public Text widhtText;
    public GameObject okWidth;

    private int contW;
    private int width;

    public void Start()
    {
        okWidth.gameObject.SetActive(false);
        contW = 0;
        PlayerPrefs.SetInt("ContinueW", contW);
    }
    public void WDropdown(int val)
    {
        if (val == 0)
        {
            contW = 0;
            PlayerPrefs.SetInt("ContinueW", contW);
        }
        if (val == 1)
        {
            widhtText.text = "Thin";
            okWidth.gameObject.SetActive(true);
            width = 3;
            PlayerPrefs.SetInt("Widht", width);
            contW = 1;
            PlayerPrefs.SetInt("ContinueW", contW);
        }
        if (val == 2)
        {
            widhtText.text = "Intermediate";
            okWidth.gameObject.SetActive(true);
            width = 2;
            PlayerPrefs.SetInt("Widht", width);
            contW = 1;
            PlayerPrefs.SetInt("ContinueW", contW);
        }
        if (val == 3)
        {
            widhtText.text = "Thick";
            okWidth.gameObject.SetActive(true);
            width = 1;
            PlayerPrefs.SetInt("Widht", width);
            contW = 1;
            PlayerPrefs.SetInt("ContinueW", contW);
        }
    }
}
