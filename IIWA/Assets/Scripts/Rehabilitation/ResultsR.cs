using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using System.Text;
using System.Linq;

public class ResultsR : MonoBehaviour
{
    public Text textoRelojB, textoFueraB, textoWidhtB, textoGroupB, textoPositionB, textoNPathsB;
    public Text textoRelojO, textoFueraO, textoWidhtO, textoGroupO, textoScore, textoPositionO, textoNPathsO;
    public GameObject panelWith;
    public GameObject panelWithout;

    private int tiempoMin, tiempoSeg, numFuera, widht, group, modeR, score, session, position, nPaths;
    private string percentage, savedName, savedDate, modeText;

    private string textoRelojFinal, textoGroupFinal, textoVecesFuera, textoWidhtFinal, textoPositionFinal, textoNPathsFinal, textoScoreFinal;

    private String ruta;
    private String separador;

    // Start is called before the first frame update
    void Start()
    {
        panelWithout.gameObject.SetActive(false);
        panelWith.gameObject.SetActive(false);

        /*GROUP OF PATHS*/
        group = PlayerPrefs.GetInt("RehabilitationPath");
        if (group == 1)
        {
            textoGroupFinal = group.ToString("Straight");
        }

        if (group == 2)
        {
            textoGroupFinal = group.ToString("Widht");
        }      

        /*WIDHT*/
        widht = PlayerPrefs.GetInt("Widht");
        if (widht == 1)
        {
            textoWidhtFinal = widht.ToString("Thin");
        }

        if (widht == 2)
        {
            textoWidhtFinal = widht.ToString("Intermediate");
        }

        if (widht == 3)
        {
            textoWidhtFinal = widht.ToString("Thick");
        }
        
        /*POSITION*/
        position = PlayerPrefs.GetInt("Position");
        if (position == 1)
        {
            textoPositionFinal = position.ToString("Vertical");
        }

        if (position == 2)
        {
            textoPositionFinal = position.ToString("Horizontal");
        }

        /*NUMBER OF PATHS*/
        nPaths = PlayerPrefs.GetInt("Paths");
        if (nPaths == 1)
        {
            textoNPathsFinal = widht.ToString("1 Path");
        }

        if (nPaths == 2)
        {
            textoNPathsFinal = widht.ToString("2 Paths");
        }

        if (nPaths == 3)
        {
            textoNPathsFinal = widht.ToString("Horizontal");
        }

        /*TIEMPO FINAL*/
        tiempoMin = PlayerPrefs.GetInt("TiempoMin");
        tiempoSeg = PlayerPrefs.GetInt("TiempoSeg");
        textoRelojFinal = tiempoMin.ToString("00") + ":" + tiempoSeg.ToString("00");

        /*NUMERO DE SALIDAS*/
        numFuera = PlayerPrefs.GetInt("VecesFuera");
        textoVecesFuera = numFuera.ToString("0" + " times");

        /*SCORE*/
        modeR = PlayerPrefs.GetInt("GameModeRe");

        if (modeR == 1)
        {
            modeText = "Basic";
            score = 0;
            panelWithout.gameObject.SetActive(true);
            panelWith.gameObject.SetActive(false);
            /*GROUP*/
            textoGroupB.text = textoGroupFinal;
            /*WIDHT*/
            textoWidhtB.text = textoWidhtFinal;
            /*POSITION*/
            textoPositionB.text = textoPositionFinal;
            /*NUMBER OF PATHS*/
            textoNPathsB.text = textoNPathsFinal;
            /*TIEMPO FINAL*/
            textoRelojB.text = textoRelojFinal;
            /*NUMERO DE SALIDAS*/
            textoFueraB.text = textoVecesFuera;
        }
        if (modeR == 2)
        {
            modeText = "Obstacles";
            score = PlayerPrefs.GetInt("ScoreDinamic");
            textoScoreFinal = score.ToString();
            textoScore.text = textoScoreFinal;
            panelWithout.gameObject.SetActive(false);
            panelWith.gameObject.SetActive(true);
            /*GROUP*/
            textoGroupO.text = textoGroupFinal;
            /*WIDHT*/
            textoWidhtO.text = textoWidhtFinal;
            /*POSITION*/
            textoPositionO.text = textoPositionFinal;
            /*NUMBER OF PATHS*/
            textoNPathsO.text = textoNPathsFinal;
            /*TIEMPO FINAL*/
            textoRelojO.text = textoRelojFinal;
            /*NUMERO DE SALIDAS*/
            textoFueraO.text = textoVecesFuera;
        }
    }

    public void SaveResults()
    {

        savedName = PlayerPrefs.GetString("Name");
        savedDate = DateTime.Now.ToString("dd-MM-yyyy");
        session = PlayerPrefs.GetInt("Session");

        /*--------------------------GUARDAR DATOS EN CSV----------------------------*/
        //ruta = "C:\\...\\" + savedName + ".csv"; //PonerURL
        separador = ";";

        StringBuilder results = new StringBuilder();
        StringBuilder rspace = new StringBuilder();

        string dataStart = savedDate + ";" + session + ";" + "   ---------->" + ";" + textoGroupFinal + ";" + percentage + "%" + ";" + textoRelojFinal + ";" + numFuera + ";" + modeText + ";" + score;  
        string spaces = "";

        List<String> lista = new List<string>();
        List<String> lista1 = new List<string>();

        lista.Add(dataStart);
        lista1.Add(dataStart);

        for (int i = 0; i < lista.Count; i++)
        {
            results.AppendLine(string.Join(separador, lista[i]));
            File.AppendAllText(ruta, dataStart.ToString());
        }

        for (int i = 0; i < lista1.Count; i++)
        {
            results.AppendLine(string.Join(separador, lista1[i]));
            File.AppendAllText(ruta, spaces.ToString());
        }
        /*------------------------FIN GUARDAR DATOS EN CSV--------------------------*/
    }
}
