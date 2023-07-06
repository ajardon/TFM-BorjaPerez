using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SavePath : MonoBehaviour
{
    public int path;
    public Text myPath;

    public void ChoosePath()
    {
        string pathText;
        PlayerPrefs.SetInt("PathElegido", path); 
        pathText = ("Path " + path);
        myPath.text = pathText;
    }
}
