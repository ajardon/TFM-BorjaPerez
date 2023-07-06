using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using System.Text;
using System.Linq;

public class ResultsE : MonoBehaviour
{
    public Text textoRelojB, textoFueraB, textoSizeB, textoPathB, textoGroupB;
    public Text textoRelojO, textoFueraO, textoSizeO, textoPathO, textoGroupO, textoScore;
    public GameObject panelWith;
    public GameObject panelWithout;

    private int tiempoMin, tiempoSeg, numFuera, path, group, mode, score, session;
    private string percentage, savedName, savedDate, modeText;

    private string textoRelojFinal, textoVecesFuera, textoSizeFinal, textoPathFinal, textoGroupFinal, textoScoreFinal;

    private String ruta;
    private String separador;

    // Start is called before the first frame update
    void Start()
    {
        panelWithout.gameObject.SetActive(false);
        panelWith.gameObject.SetActive(false);

        /*GROUP OF PATHS*/
        group = PlayerPrefs.GetInt("SavedGroup");

        if (group == 1)
        {
            textoGroupFinal = group.ToString("Complexity");
        }
        if (group == 2)
        {
            textoGroupFinal = group.ToString("Straight to curvy");
        }
        if (group == 3)
        {
            textoGroupFinal = group.ToString("Widht");
        }     

        /*PATH*/
        path = PlayerPrefs.GetInt("PathElegido");
        textoPathFinal = path.ToString(); 

        /*SIZE*/
        percentage = PlayerPrefs.GetString("Percentage");
        textoSizeFinal = percentage.ToString() + "%";


        /*TIEMPO FINAL*/
        tiempoMin = PlayerPrefs.GetInt("TiempoMin");
        tiempoSeg = PlayerPrefs.GetInt("TiempoSeg");
        textoRelojFinal = tiempoMin.ToString("00") + ":" + tiempoSeg.ToString("00");

        /*NUMERO DE SALIDAS*/
        numFuera = PlayerPrefs.GetInt("VecesFuera");
        textoVecesFuera = numFuera.ToString("0" + " times");

        /*SCORE*/
        mode = PlayerPrefs.GetInt("GameModeE");

        if (mode == 1)
        {
            modeText = "Basic";
            score = 0;
            panelWithout.gameObject.SetActive(true);
            panelWith.gameObject.SetActive(false);
            /*SIZE*/
            textoSizeB.text = textoSizeFinal;
            /*PATH*/
            textoPathB.text = textoPathFinal;
            /*TIEMPO FINAL*/
            textoRelojB.text = textoRelojFinal;
            /*NUMERO DE SALIDAS*/
            textoFueraB.text = textoVecesFuera;
            /*GROUP OF PATHS*/
            textoGroupB.text = textoGroupFinal;
        }
        if (mode == 2)
        {
            modeText = "Obstacles";
            score = PlayerPrefs.GetInt("ScoreDinamic");
            textoScoreFinal = score.ToString();
            textoScore.text = textoScoreFinal;
            panelWithout.gameObject.SetActive(false);
            panelWith.gameObject.SetActive(true);
            /*SIZE*/
            textoSizeO.text = textoSizeFinal;
            /*PATH*/
            textoPathO.text = textoPathFinal;
            /*TIEMPO FINAL*/
            textoRelojO.text = textoRelojFinal;
            /*NUMERO DE SALIDAS*/
            textoFueraO.text = textoVecesFuera;
            /*GROUP OF PATHS*/
            textoGroupO.text = textoGroupFinal;
        }
    }

    public void SaveResults()
    {
        
        savedName = PlayerPrefs.GetString("Name");
        savedDate = DateTime.Now.ToString("dd-MM-yyyy");
        session = PlayerPrefs.GetInt("Session");

        /*--------------------------GUARDAR DATOS EN CSV----------------------------*/
        //ruta = "C:\\...\\" + savedName + ".csv"; //Poner URL
        separador = ";";

        StringBuilder results = new StringBuilder();
        StringBuilder rspace = new StringBuilder();

        string dataStart = savedDate + ";" + session + ";" + "   ---------->" + ";" + textoGroupFinal + ";" + path + ";" + percentage + "%" + ";" + textoRelojFinal + ";" + numFuera + ";" + modeText + ";" + score; 
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
