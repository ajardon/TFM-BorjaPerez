using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SaveMode : MonoBehaviour
{
    public Text textMode;
    public int mode;
    public void ChooseMode()
    {
        string modeText;
        PlayerPrefs.SetInt("ChosenMode", mode);
        if (mode == 0)
        {
            modeText = ("Basic Mode");
            textMode.text = modeText;
        }
        if (mode == 1)
        {
            modeText = ("Game Mode");
            textMode.text = modeText;
        }

    }
}
