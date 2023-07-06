using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameModeDropdownS : MonoBehaviour
{
    public Text gameModeText;
    public GameObject okGameMode;

    private int gameMode, contGM;

    public void Start()
    {
        okGameMode.gameObject.SetActive(false);
        contGM = 0;
        PlayerPrefs.SetInt("ContinueGMR", contGM);
    }
    public void GMDropdown(int val)
    {
        if (val == 0)
        {
            contGM = 0;
            PlayerPrefs.SetInt("ContinueW", contGM);
        }
        if (val == 1)
        {
            gameModeText.text = "Basic";
            okGameMode.gameObject.SetActive(true);
            gameMode = 1;
            PlayerPrefs.SetInt("GameModeE", gameMode);
            contGM = 1;
            PlayerPrefs.SetInt("ContinueGMR", contGM);
        }
        if (val == 2)
        {
            gameModeText.text = "Obstacles";
            okGameMode.gameObject.SetActive(true);
            gameMode = 2;
            PlayerPrefs.SetInt("GameModeE", gameMode);
            contGM = 1;
            PlayerPrefs.SetInt("ContinueGMR", contGM);
        }
    }
}
