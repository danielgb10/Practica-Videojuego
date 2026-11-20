using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptInterruptor : MonoBehaviour
{
    public Color colorPulsado;
    public Color colorEnReposo;
    public GameObject puerta;

    bool pulsado;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        pulsado = true;
        Debug.Log("Pisado el botón");
        SpriteRenderer dibujo = GetComponent<SpriteRenderer>();
        dibujo.color = colorPulsado;
    }

    public bool EstaPulsado()
    {
        return pulsado;
    }
}

