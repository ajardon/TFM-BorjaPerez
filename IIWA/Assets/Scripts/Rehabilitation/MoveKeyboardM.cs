using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKeyboardM : MonoBehaviour
{
    public float movespeed = 5f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * movespeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
    }
}
