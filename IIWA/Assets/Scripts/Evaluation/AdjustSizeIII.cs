using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdjustSizeIII : MonoBehaviour
{
    public GameObject path7;
    public GameObject path8;
    public GameObject path9;
    public Slider sliderEscalar;
    public Text percentageText;

    private float tamaño = 1;
    private int chosenPath, saved;
    private double percentage;
    private string percent;

    void Start()
    {
        EscalarModelo();
        saved = 0;
    }
    public void EscalarModelo()
    {
        chosenPath = PlayerPrefs.GetInt("PathElegido");
        if (chosenPath == 7)
        {
            path7.gameObject.SetActive(true);
            path8.gameObject.SetActive(false);
            path9.gameObject.SetActive(false);
            path7.transform.localScale = new Vector3(sliderEscalar.value, sliderEscalar.value, sliderEscalar.value);
            tamaño = sliderEscalar.value;
            percentage = ((sliderEscalar.value * 100) / 0.5) - 200;
            percent = percentage.ToString("0");
            percentageText.text = percent;
        }
        if (chosenPath == 8)
        {
            path7.gameObject.SetActive(false);
            path8.gameObject.SetActive(true);
            path9.gameObject.SetActive(false);
            path8.transform.localScale = new Vector3(sliderEscalar.value, sliderEscalar.value, sliderEscalar.value);
            tamaño = sliderEscalar.value;
            percentage = ((sliderEscalar.value * 100) / 0.5) - 200;
            percent = percentage.ToString("0");
            percentageText.text = percent;
        }
        if (chosenPath == 9)
        {
            path7.gameObject.SetActive(false);
            path8.gameObject.SetActive(false);
            path9.gameObject.SetActive(true);
            path9.transform.localScale = new Vector3(sliderEscalar.value, sliderEscalar.value, sliderEscalar.value);
            tamaño = sliderEscalar.value;
            percentage = ((sliderEscalar.value * 100) / 0.5) - 200;
            percent = percentage.ToString("0");
            percentageText.text = percent;
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("EscalarTamaño", tamaño);
        PlayerPrefs.SetString("Percentage", percent);
        saved = 1;
        PlayerPrefs.SetInt("okSize", saved);
    }
    public void VolverAAjustes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
    }
}
