using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public class SaveData : MonoBehaviour
{
    public GameObject exists;

    private string dateToday, session, time, resultsText, age, pathology, side, sideText, group, path, size, totaltime, outOfTheWay, mode, score;
    private string savedDate, savedTime, savedName, savedAge, savedPathology, savedSide;
    private string inputName, inputAge, inputPathology, inputSide;

    private String ruta;
    private String separador;

    private string userName;
    private int i, savedSession;

    // private int yes=0;

    void Start()
    {
        session = "SESSION";
        name = "NAME";
        age = "AGE";
        pathology = "PATHOLOGY";
        side = "SIDE";
        dateToday = "DATE";
        time = "TIME";
        resultsText = "RESULTS";
        group = "GROUP";
        path = "PATH";
        size = "SIZE";
        totaltime = "TOTAL TIME";
        outOfTheWay = "OUT OF THE WAY";
        mode = "MODE";
        score = "SCORE";


        i = PlayerPrefs.GetInt("i");

        exists.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SaveName(string name)
    {
        inputName = name;
        PlayerPrefs.SetString("Name", inputName);
    }

    public void SaveAge(string age)
    {
        inputAge = age;
        PlayerPrefs.SetString("Age", inputAge);
    }

    public void SavePathology(string pathology)
    {
        inputPathology = pathology;
        PlayerPrefs.SetString("Pathology", inputPathology);        
    }
    public void SideDropdown(int val)
    {
        if (val == 1)
        {
            sideText = val.ToString("Left");
        }
        if (val == 2)
        {
            sideText = val.ToString("Right");
        }
    }

    public void SaveAll()
    {
        savedName = PlayerPrefs.GetString("Name");
        savedAge = PlayerPrefs.GetString("Age");
        savedPathology = PlayerPrefs.GetString("Pathology");
        savedSession = 1;
        PlayerPrefs.SetInt("Session", savedSession);

        /*--------------------------GUARDAR DATOS EN CSV----------------------------*/
        //ruta = "C:\\..." + savedName + ".csv"; //Poner ruta
        separador = ";";

        StringBuilder prueba = new StringBuilder();
        StringBuilder salida = new StringBuilder();
        StringBuilder space1 = new StringBuilder();
        StringBuilder results = new StringBuilder();


        string principio = name + ";" + age + ";" + pathology + ";" + side; 
        string cadena = savedName + ";" + savedAge + ";" + savedPathology + ";" + sideText; 
        string spaces1 = ""; 
        string resultsNames = dateToday + ";" + session + ";" + resultsText + ";" + group + ";" + path + ";" + size + ";" + totaltime + ";" + outOfTheWay + ";" + mode + ";" + score;

        List<String> lista2 = new List<string>();
        List<String> lista3 = new List<string>();
        List<String> lista4 = new List<string>();
        List<String> lista5 = new List<string>();

        lista2.Add(principio);
        lista3.Add(cadena);
        lista4.Add(spaces1);
        lista5.Add(resultsNames);

        for (int i = 0; i < lista2.Count; i++) 
        {
            prueba.AppendLine(string.Join(separador, lista2[i]));
            File.AppendAllText(ruta, prueba.ToString());
        }
        
        for (int i = 0; i < lista3.Count; i++) 
        {
            salida.AppendLine(string.Join(separador, lista3[i]));
            File.AppendAllText(ruta, salida.ToString());
        }
        
        for (int i = 0; i < lista4.Count; i++) 
        {
            space1.AppendLine(string.Join(separador, lista4[i]));
            File.AppendAllText(ruta, space1.ToString());
        }

        for (int i = 0; i < lista5.Count; i++) 
        {
            results.AppendLine(string.Join(separador, lista5[i]));
            File.AppendAllText(ruta, results.ToString());
        }

        /*------------------------FIN GUARDAR DATOS EN CSV--------------------------*/

        /*--------------------------GUARDAR LOS NOMBRE EN CSV----------------------------*/
        //ruta = "C:\\...\\Users.csv"; //Poner ruta
        separador = ";";

        StringBuilder usuarios = new StringBuilder();

        string nombres = savedName;
        
        List<String> lista10 = new List<string>();

        lista10.Add(nombres);

        for (int i = 0; i < lista10.Count; i++)
        {
            usuarios.AppendLine(string.Join(separador, lista10[i]));
            File.AppendAllText(ruta, usuarios.ToString());
        }

        /*------------------------FIN GUARDAR LOS NOMBRES EN CSV--------------------------*/
    }
}
