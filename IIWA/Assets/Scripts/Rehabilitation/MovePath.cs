using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MovePath : MonoBehaviour
{
    private float speed;
    private int yesV, start, start1, end, stop, movePath, position;
    public GameObject vertical1;
    public GameObject vertical2;
    public GameObject vertical3;
    public GameObject vertical1M;
    public GameObject vertical2M;
    public GameObject vertical3M;
    public GameObject horizontal1;
    public GameObject horizontal2;
    public GameObject horizontal3;
    public GameObject coinsH, coinsV;


    private void Start()
    {
        /*----------Que no se mueva hasta que se presione el espacio-------*/
        start = 0;
        end = 0;
        movePath = 0;
        /*-----------------------------FIN--------------------------------*/
        speed = PlayerPrefs.GetFloat("Speed");
        stop = 0;
    }
    void Update()
    {
        movePath = PlayerPrefs.GetInt("StartMovingPath");

        if ((movePath==1) && (end == 0))
        {

            start = 1;
            PlayerPrefs.GetInt("Start", start1);
            end = 1;

        }

        speed = PlayerPrefs.GetFloat("Speed");

        if (start == 1)
        {
                vertical1.transform.Translate(0, 0, -speed);
                vertical2.transform.Translate(0, 0, -speed);
                vertical3.transform.Translate(0, 0, -speed);
                vertical1M.transform.Translate(0, 0, -speed);
                vertical2M.transform.Translate(0, 0, -speed);
                vertical3M.transform.Translate(0, 0, -speed);
                horizontal1.transform.Translate(0, 0, -speed);
                horizontal2.transform.Translate(0, 0, -speed);
                horizontal3.transform.Translate(0, 0, -speed);
                coinsV.transform.Translate(0, 0, speed);
                coinsH.transform.Translate(-speed, 0, 0);
        }

    }
}
    
