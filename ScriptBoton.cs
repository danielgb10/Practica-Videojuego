using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBoton : MonoBehaviour, IPulsable
{
    public Color colorPulsado;

    public Color colorEnReposo;

    public GameObject puerta;

    bool pulsado;

    int contador;

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

    void OnTriggerExit2D(Collider2D collision)
    {
        contador--;
        Debug.Log("Salido del botón");
        Debug.Log("No hay nada");
        SpriteRenderer dibujo = GetComponent<SpriteRenderer>();
        dibujo.color = colorEnReposo;
    }

    public bool EstaPulsado()
    {
        return pulsado;
    }
}
