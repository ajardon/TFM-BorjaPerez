using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System.Linq;
using System;

public class SavePosition : MonoBehaviour
{
    public GameObject ball;
    private float posicionx;
    private float posiciony;
    private float posicionz;
    private float wait = 0.3f;
    private float timer;
    private string savedName;
    private String ruta;
    private String separador;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("POSICION INICIAL " + transform.position);
        //HAY QUE PONER LA RUTA PARA QUE FUNCIONE

        /*savedName = PlayerPrefs.GetString("Name");
        /ruta = "C:\\...\\Position" + savedName + ".csv"; //HAY QUE PONER LA RUTA
        separador = ";";
        StringBuilder xyz = new StringBuilder();
        string pos = "X" + ";" + "Y";
        List<String> list = new List<string>();
        list.Add(pos);

        for (int i = 0; i < list.Count; i++)
        {
            xyz.AppendLine(string.Join(separador, list[i]));
            File.AppendAllText(ruta, xyz.ToString());
        }

        SetPosicion();*/
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= wait)
        {
            posicionx = ball.transform.position.x;
            posiciony = ball.transform.position.y;
            SetPosicion();
            timer = .0f;
        }
    }

    void SetPosicion()
    {
        //HAY QUE PONER LA RUTA PARA QUE FUNCIONE

        /* savedName = PlayerPrefs.GetString("Name");
        ruta = "C:\\...\\Position" + savedName + ".csv"; 
        separador = ";";

        StringBuilder position = new StringBuilder();

        string user = posicionx + ";" + posiciony;

        List<String> list1 = new List<string>();

        list1.Add(user);

        for (int i = 0; i < list1.Count; i++)
        {
            position.AppendLine(string.Join(separador, list1[i]));
            File.AppendAllText(ruta, position.ToString());
        }*/
    }
}
