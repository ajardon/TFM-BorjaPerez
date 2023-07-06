using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class AdjustSizeII : MonoBehaviour
{
    public GameObject path4;
    public GameObject path5;
    public GameObject path6;
    public Slider sliderEscalar;
    public Text percentageText;

    private float tamaño = 1;
    private int chosenPath, saved, contSi;
    private double percentage;
    private string percent;

    void Start()
    {
        ChooseSize();
        saved = 0;
        contSi = 0;
        PlayerPrefs.SetInt("ContinueSi", contSi);
    }
    public void ChooseSize()
    {
        chosenPath = PlayerPrefs.GetInt("PathElegido");

        if (chosenPath == 4)
        {
            path4.gameObject.SetActive(true);
            path5.gameObject.SetActive(false);
            path6.gameObject.SetActive(false);
            path4.transform.localScale = new Vector3(sliderEscalar.value, sliderEscalar.value, sliderEscalar.value);
            tamaño = sliderEscalar.value;
            percentage = ((sliderEscalar.value * 100) / 0.5) - 200;
            percent = percentage.ToString("0");
            percentageText.text = percent;
        }
        if (chosenPath == 5)
        {
            path4.gameObject.SetActive(false);
            path5.gameObject.SetActive(true);
            path6.gameObject.SetActive(false);
            path5.transform.localScale = new Vector3(sliderEscalar.value, sliderEscalar.value, sliderEscalar.value);
            tamaño = sliderEscalar.value;
            percentage = ((sliderEscalar.value * 100) / 0.5) - 200;
            percent = percentage.ToString("0");
            percentageText.text = percent;
        }
        if (chosenPath == 6)
        {
            path4.gameObject.SetActive(false);
            path5.gameObject.SetActive(false);
            path6.gameObject.SetActive(true);
            path6.transform.localScale = new Vector3(sliderEscalar.value, sliderEscalar.value, sliderEscalar.value);
            percentage = ((sliderEscalar.value * 100) / 0.5) - 200;
            percent = percentage.ToString("0");
            percentageText.text = percent;
        }
    }
    public void SaveData()
    {
        PlayerPrefs.SetFloat("EscalarTamaño", tamaño);
        PlayerPrefs.SetString("Percentage", percent);
        Debug.Log(percent);
        saved = 1;
        PlayerPrefs.SetInt("okSize", saved);
        contSi = 1;
        PlayerPrefs.SetInt("ContinueSi", contSi);
    }

    public void VolverAAjustes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
    }
}

