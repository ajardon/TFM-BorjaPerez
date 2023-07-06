using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PathsDropdown : MonoBehaviour
{
    public Text pathsText;
    public GameObject okPaths;

    private int contPa = 0;
    private int paths;
    private int borrar;

    public void Start()
    {
        okPaths.gameObject.SetActive(false);
        contPa = 0;
        PlayerPrefs.SetInt("ContinuePa", contPa);
    }

    public void Update()
    {
        borrar = PlayerPrefs.GetInt("Borrar");

        if (borrar == 1)
        {
            PaDropdown(0);

        }
    }

    public void PaDropdown(int val)
    {
        if (val == 0)
        {
            contPa = 0;
            pathsText.text = "...";
            PlayerPrefs.SetInt("ContinuePa", contPa);
        }
        if (val == 1) //1 PATH
        {
            pathsText.text = "1 Path";
            okPaths.gameObject.SetActive(true);
            paths= 1;
            PlayerPrefs.SetInt("Paths", paths);
            contPa = 1;
            PlayerPrefs.SetInt("ContinuePa", contPa);
        }
        if (val == 2) //2 PATHS
        {
            pathsText.text = "2 Paths";
            okPaths.gameObject.SetActive(true);
            paths = 2;
            PlayerPrefs.SetInt("Paths", paths);
            contPa = 1;
            PlayerPrefs.SetInt("ContinuePa", contPa);
        }
    }
}
