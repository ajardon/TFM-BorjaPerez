using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*En Hierarchy se van creando muchos sonidos y con esto se destruyen en el tiempo de vida que le pongamos*/

public class Lifetime : MonoBehaviour
{
    public float lifeTime;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}









