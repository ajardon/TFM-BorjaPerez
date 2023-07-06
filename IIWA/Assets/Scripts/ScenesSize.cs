using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ScenesSize : MonoBehaviour
{
    private int chosenPath, chosenMode, saved, contSi, contS, contGMR;

    private string percent;
    public Text percentageText;
    public GameObject okSize, continueButtonR;



    private void Start()
    {
        okSize.gameObject.SetActive(false);
        continueButtonR.gameObject.SetActive(false);
        saved = 0;
    }
    private void Update()
    {
        saved = PlayerPrefs.GetInt("okSize");
        if (saved == 1)
        {
            percent = PlayerPrefs.GetString("Percentage");
            percentageText.text = percent +"%";
            okSize.gameObject.SetActive(true);
        }
        else
        {
            percentageText.text = ("...");
            okSize.gameObject.SetActive(false);
        }

        contSi = PlayerPrefs.GetInt("ContinueSi");
        contGMR = PlayerPrefs.GetInt("ContinueGMR");

        if ((contSi == 1) & (contGMR == 1))
        {
            continueButtonR.gameObject.SetActive(true);
        }
        else
        {
            continueButtonR.gameObject.SetActive(false);

        }
    }
    public void ChangeToSize()
    {
        chosenPath = PlayerPrefs.GetInt("PathElegido");
        
        if (chosenPath == 1 | chosenPath == 2 | chosenPath == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (chosenPath == 4 | chosenPath == 5 | chosenPath == 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        if (chosenPath == 7 | chosenPath == 8 | chosenPath == 9)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }

    }
    public void StartGame()
    {
        chosenPath = PlayerPrefs.GetInt("PathElegido");

            if (chosenPath == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
            }
            if (chosenPath == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
            }
            if (chosenPath == 3)
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
            }
            if (chosenPath == 4)
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
            }
            if (chosenPath == 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);
            }
            if (chosenPath == 6)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 9);
            }
            if (chosenPath == 7)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 10);
            }
            if (chosenPath == 8)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 11);
            }
            if (chosenPath == 9)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 12);
            }
    }
}

