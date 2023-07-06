using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int scene;
    private int prueba;

    public void ChangeTheScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + scene); 
    }


    public void CambiarEscenaAncho()
    {
        
        if (prueba == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
        if (prueba == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        }
        if (prueba == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
        }
    }
}
