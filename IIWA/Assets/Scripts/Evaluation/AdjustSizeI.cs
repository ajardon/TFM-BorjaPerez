using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdjustSizeI : MonoBehaviour
{
    public GameObject path1;
    public GameObject path2;
    public GameObject path3;
    public Slider sliderEscalar;
    public Text percentageText;

    private float tamaño = 1;
    private int chosenPath, contSi;
    private int saved;
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
        if (chosenPath == 1)
        {
            path1.gameObject.SetActive(true);
            path2.gameObject.SetActive(false);
            path3.gameObject.SetActive(false);
            path1.transform.localScale = new Vector3(sliderEscalar.value, sliderEscalar.value, sliderEscalar.value);
            tamaño = sliderEscalar.value;

            percentage = ((sliderEscalar.value * 100) / 0.5)-200;
            percent = percentage.ToString("0" );
            percentageText.text = percent;
        }
        if (chosenPath == 2)
        {
            path1.gameObject.SetActive(false);
            path2.gameObject.SetActive(true);
            path3.gameObject.SetActive(false);
            path2.transform.localScale = new Vector3(sliderEscalar.value, sliderEscalar.value, sliderEscalar.value);
            tamaño = sliderEscalar.value;

            percentage = ((sliderEscalar.value * 100) / 0.5) - 200;
            percent = percentage.ToString("0");
            percentageText.text = percent;
        }
        if (chosenPath == 3)
        {
            path1.gameObject.SetActive(false);
            path2.gameObject.SetActive(false);
            path3.gameObject.SetActive(true);
            path3.transform.localScale = new Vector3(sliderEscalar.value, sliderEscalar.value, sliderEscalar.value);
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
        contSi = 1;
        PlayerPrefs.SetInt("ContinueSi", contSi);
    }

    public void VolverAAjustes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
    }
}
