using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PositionDropdown : MonoBehaviour
{
    public Text positionText;
    public Text pathText;
    public GameObject okPosition;
    public GameObject okPaths;
    public GameObject dropdownPaths;
    public GameObject warning;

    private int contP = 0;
    private int contPa = 0;
    private int position;
    private int warn=0;
    private int BORRAR=0;
    private PathsDropdown drop;

    public void Start()
    {
        okPosition.gameObject.SetActive(false);
        okPaths.gameObject.SetActive(false);
        warning.gameObject.SetActive(false);
        contP = 0;
        PlayerPrefs.SetInt("ContinueP", contP);
    }

    public void Update()
    {
        if (warn == 1) //HORIZONTAL
        {
            warning.gameObject.SetActive(true);
            
            dropdownPaths.gameObject.SetActive(false); 
            
        }
        if (warn == 0) //VERTICAL
        {
            warning.gameObject.SetActive(false);
            
            dropdownPaths.gameObject.SetActive(true);
            
        }

    }

    public void PDropdown(int val)
    {
        if (val == 0)
        {
            contP = 0;
            PlayerPrefs.SetInt("ContinueP", contP);
        }
        if (val == 1) //VERTICAL
        {
            positionText.text = "Vertical";
            okPosition.gameObject.SetActive(true);
            position = 1;
            PlayerPrefs.SetInt("Position", position);
            contP = 1;
            PlayerPrefs.SetInt("ContinueP", contP);
            warn = 0;
            BORRAR = 1;
            PlayerPrefs.GetInt("Borrar", BORRAR);
        }
        if (val == 2) //HORIZONTAL
        {
            positionText.text = "Horizontal";
            okPosition.gameObject.SetActive(true);
            position = 2;
            PlayerPrefs.SetInt("Position", position);
            contP = 1;
            PlayerPrefs.SetInt("ContinueP", contP);                   
            warn = 1;
            okPaths.gameObject.SetActive(true);
            pathText.text = "1 Path";
            contPa = 1;
            PlayerPrefs.SetInt("ContinuePa", contPa);

        }
    }
}
