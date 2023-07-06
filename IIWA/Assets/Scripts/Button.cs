using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private int widht;
    
    // Start is called before the first frame update
    void Start()
    {
     
    }
    public void SaveWidhtA()
    {
        widht = 0;
        PlayerPrefs.SetFloat("ElegirAncho", widht);
    }
    public void SaveWidhtB()
    {
        widht = 1;
        PlayerPrefs.SetFloat("ElegirAncho", widht);
    }
    public void SaveWidhtC()
    {
        widht = 2;
        PlayerPrefs.SetFloat("ElegirAncho", widht);
    }


}
