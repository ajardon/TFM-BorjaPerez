using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveExo : MonoBehaviour
{
    public float movespeed;
    private int movement = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = PlayerPrefs.GetInt("Movement");

        if (movement == 0)
        {
            transform.Translate(Vector3.right * 0 * Time.deltaTime);
            Debug.Log("Parado");
        }
        if (movement == 1)
        {
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
            Debug.Log("Arriba");
        }
        if (movement == 2)
        {
            transform.Translate(-Vector3.forward * movespeed * Time.deltaTime);
            Debug.Log("Abajo");
        }
        if (movement == 3)
        {
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
            Debug.Log("Izquierda");
        }
        if (movement == 4)
        {
            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
            Debug.Log("Derecha");
        }

    }
}
