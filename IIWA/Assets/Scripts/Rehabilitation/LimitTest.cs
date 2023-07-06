using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;
using System.IO;

public class LimitTest : MonoBehaviour
{
    public GameObject imagen;
    private int i;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Path"))
        {
            i++;
            Debug.Log(i);
            imagen.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("FUERA");

            imagen.gameObject.SetActive(false);
        }
    }
}
