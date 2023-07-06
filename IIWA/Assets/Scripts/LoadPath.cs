using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPath : MonoBehaviour
{
    public GameObject path, coins, score, EvalBallM;

    private float size;
    private int gameMode, ball;

    private void Start()
    {
        coins.gameObject.SetActive(false);
        score.gameObject.SetActive(false);
        EvalBallM.gameObject.SetActive(false);

        LoadThePath();
    }

    public void LoadThePath()
    {
        size = PlayerPrefs.GetFloat("EscalarTamaño");
        path.transform.localScale = new Vector3(size, size, size);

        gameMode = PlayerPrefs.GetInt("GameModeE");
        ball = PlayerPrefs.GetInt("Ball");

        if (gameMode == 1)
        {
            coins.gameObject.SetActive(false);
            score.gameObject.SetActive(false);
        }
        if (gameMode == 2)
        {
            coins.gameObject.SetActive(true);
            score.gameObject.SetActive(true);
        }

        if (ball == 0)
        {
            EvalBallM.gameObject.SetActive(true);
        }
        if (ball == 1)
        {
            EvalBallM.gameObject.SetActive(false);
        }
        if (ball == 2)
        {
            EvalBallM.gameObject.SetActive(false);
        }

    } 
}
 