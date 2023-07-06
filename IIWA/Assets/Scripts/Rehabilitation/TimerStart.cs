using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class TimerStart : MonoBehaviour
{
    private float TimeToDestroy=4f;
    public Text Timertext;
    public GameObject timer;
    public Timer startTimer;

    private int TimerToText, startGame, move;

    private void Start()
    {
        startGame = 0;
        move = 0;
    }

    private void Update()
    {
        if (startGame == 1)
        {
            TimeToDestroy -= Time.deltaTime*0.5f;
            TimerToText = (int)TimeToDestroy; 
            Timertext.text = TimerToText.ToString();
            if (TimeToDestroy <= 0)
            {
                move = 1;
                PlayerPrefs.SetInt("StartMovingPath", move);
                timer.gameObject.SetActive(false);
                startTimer.StartClock();
                startGame = 0;
            }
        }
    }

    public void StartTimer()
    {
       startGame = 1;
    }
}