using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class FillDropdown : MonoBehaviour
{
    public Dropdown dropdown; 
    
    // Start is called before the first frame update
    void Start()
    {
        FillDropdownFunction();
    }

    public void FillDropdownFunction()
    {
        //HAY QUE PONER LA RUTA PARA QUE FUNCIONE
        
        //string[] users = File.ReadAllLines("D:\\MARIA\\TFM\\CSV\\Users.csv"); 
        //List<string> names= users.ToList();
        //dropdown.AddOptions(names);
    }
}
