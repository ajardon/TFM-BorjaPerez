using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedSettings : MonoBehaviour
{
    private float speed;
    private int ball, pathLimit=0;

    public void Start()
    {

    }
    public void VDropdown(int val)
    {
        if (val == 0)
        {
            speed = 0.05f;
            PlayerPrefs.SetFloat("Speed", speed);
        }
        if (val == 1)
        {
            speed = 0.02f;
            PlayerPrefs.SetFloat("Speed", speed);
        }
        if (val == 2)
        {
            speed = 0.085f;
            PlayerPrefs.SetFloat("Speed", speed);
        }
    }
    public void BDropdown(int val)
    {
        if (val == 0) //Medium
        {
            ball = 0;
            PlayerPrefs.SetInt("Ball", ball);
        }
        if (val == 1) //Small
        {
            ball = 1;
            PlayerPrefs.SetInt("Ball", ball);
        }
        if (val == 2) //Big
        {
            ball = 2;
            PlayerPrefs.SetInt("Ball", ball);
        }
    }
    public void PLDropdown(int val)
    {
        if (val == 0) //Medium
        {
            pathLimit = 0;
            PlayerPrefs.SetInt("PathLimit", pathLimit);
        }
        if (val == 1) //Near
        {
            pathLimit = 1;
            PlayerPrefs.SetInt("PathLimit", pathLimit);
        }
        if (val == 2) //Far
        {
            pathLimit = 2;
            PlayerPrefs.SetInt("PathLimit", pathLimit);
        }
    }
}
