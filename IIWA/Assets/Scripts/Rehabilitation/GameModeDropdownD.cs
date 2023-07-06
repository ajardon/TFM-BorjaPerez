using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameModeDropdownD : MonoBehaviour
{
    public Text gameModeText;
    public GameObject okGameMode;

    private int gameModeR, contGM;

    public void Start()
    {
        okGameMode.gameObject.SetActive(false);
        contGM = 0;
        PlayerPrefs.SetInt("ContinueGM", contGM);
    }
    public void GMDropdown(int val)
    {
        if (val == 0)
        {
            contGM = 0;
            PlayerPrefs.SetInt("ContinueGM", contGM);
        }
        if (val == 1)
        {
            gameModeText.text = "Basic";
            okGameMode.gameObject.SetActive(true);
            gameModeR = 1;
            PlayerPrefs.SetInt("GameModeRe", gameModeR);
            contGM = 1;
            PlayerPrefs.SetInt("ContinueGM", contGM);

        }
        if (val == 2)
        {
            gameModeText.text = "Obstacles";
            okGameMode.gameObject.SetActive(true);
            gameModeR = 2;
            PlayerPrefs.SetInt("GameModeRe", gameModeR);
            contGM = 1;
            PlayerPrefs.SetInt("ContinueGM", contGM);


        }
    }
}
