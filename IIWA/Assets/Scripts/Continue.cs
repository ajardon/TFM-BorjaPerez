using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public GameObject continueButton;
    
    private int contW, contP, contPa, contGM;
    private int path;


    private void Start()
    {
        continueButton.gameObject.SetActive(false);
    }
    void Update()
    {
        contW = PlayerPrefs.GetInt("ContinueW");
        contP = PlayerPrefs.GetInt("ContinueP");
        contPa = PlayerPrefs.GetInt("ContinuePa");
        contGM = PlayerPrefs.GetInt("ContinueGM");

        if ((contW == 1) & (contP==1) & (contPa==1) & (contGM==1))
        {
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            continueButton.gameObject.SetActive(false);
        }
    }

    public void NextScene()
    {
        path = PlayerPrefs.GetInt("RehabilitationPath");

        if (path == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (path == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
