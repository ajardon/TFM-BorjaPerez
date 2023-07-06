using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UsersDropdown : MonoBehaviour
{

    List<string> items = new List<string>();
    public Dropdown dropdown;
    private string userName;
    private int usuarios;
    private int count;
    private int list;
    private int j;
    private int i;
    private int m;
    private string users;

    private void Start()
    {
        //SaveData usuarios;
        
    }
    public void UserUpdate()
    {


        dropdown.options.Add(new Dropdown.OptionData() { text = userName});

    }

    public void rellenarDropdown()
    {

        for (j = 0; j < m; j++)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = items[j] });
        }
    }

    public void Reset()
    {
        i = 0;
    }
    
}
