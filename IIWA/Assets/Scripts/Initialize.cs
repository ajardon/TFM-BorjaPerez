using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    private int ball, far, saved, movePath;
    private float speed, percentage;

    public void InitializeSettings()
    {
        ball = 0;
        PlayerPrefs.SetInt("Ball", ball);
        speed = 0.05f;
        PlayerPrefs.SetFloat("Speed", speed);
        far=0;
        PlayerPrefs.SetFloat("PathLimit", speed);
        saved = 0;
        PlayerPrefs.SetInt("okSize", saved);
        movePath = 0;
        PlayerPrefs.SetInt("StartMovingPath", movePath);
    }
}
