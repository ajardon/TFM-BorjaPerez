using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.IO;
using System.Globalization;

public class MoveBall : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public float z = 0.0f;
    public Timer iniciarReloj;

    private int hour, min, sec;
    private int end; //Si ya se ha iniciado el mov con la bola esto se pone a 1 y el timer ya no se inicializa al volver a coger la bola


    private void Start()
    {
        end = 0;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (end == 0) //Para que no se vuelva a inicializar el timer al soltar y coger la bola
        {
            iniciarReloj.StartClock();
            end = 1;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = z;

        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}
