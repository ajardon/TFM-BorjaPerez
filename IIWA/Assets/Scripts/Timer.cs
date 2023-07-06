using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public int tiempoInicial;
    private int minutos;
    private int segundos;
    private int tiempoTotalMin;
    private int tiempoTotalSeg;

    [Range(-10.0f, 10.0f)] 
    private float escalaDeTiempo = 0;

    private Text miTexto;
    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoEnSegundosParaMostrar = 0f;
    private float escalaDeTiempoAlPausar, escalaDeTiempoInicial;
    private bool estaPausado = false;
    // private bool evento = false;


    //Crear delegado para el evento de tiempo
    public delegate void Accion();
    //Crear eveto
    //public static event Accion AlLlegarACero;

    // Start is called before the first frame update
    void Start()
    {


        escalaDeTiempoInicial = 0;
        miTexto = GetComponent<Text>();
        tiempoEnSegundosParaMostrar = tiempoInicial; //Acumula el tiempo que va pasado

        UpdateClock(tiempoInicial); //Inicializamos nuestro reloj
    }

    void Update()
    {
        if (!estaPausado)
        {
            tiempoDelFrameConTimeScale = Time.deltaTime * escalaDeTiempo;

            tiempoEnSegundosParaMostrar += tiempoDelFrameConTimeScale;
            UpdateClock(tiempoEnSegundosParaMostrar);
        }
    }

    public float UpdateClock(float tiempoEnSegundos)
    {

        string textoDelReloj;

        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        tiempoTotalMin = minutos;
        tiempoTotalSeg = segundos;

        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00"); 

        miTexto.text = textoDelReloj;

        return segundos;
    }

    public void StartClock()
    {
        estaPausado = false;
        escalaDeTiempo = 1;
        tiempoEnSegundosParaMostrar = tiempoInicial;
        UpdateClock(tiempoEnSegundosParaMostrar);
    }
    public void Pause()
    {
        if (!estaPausado)
        {
            estaPausado = true;
            escalaDeTiempoAlPausar = escalaDeTiempo;
            escalaDeTiempo = 0;

            SaveData();
        }

    }
    public void SaveData()
    {

        PlayerPrefs.SetInt("TiempoMin", tiempoTotalMin);
        PlayerPrefs.SetInt("TiempoSeg", tiempoTotalSeg);

    }
}
