using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SaveDinamicPath : MonoBehaviour
{
    public int dinamicPath;

    public void ChooseDinamicPath()
    {
        PlayerPrefs.SetInt("RehabilitationPath", dinamicPath);
    }
}
