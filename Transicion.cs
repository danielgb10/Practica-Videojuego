using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transicion : MonoBehaviour
{
    public Transform origen;
    public Transform destino;
    bool haCruzado;

    float temporizador;
    BoxCollider2D colision;

    // Start is called before the first frame update
    void Start()
    {
        colision = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!haCruzado)
        {
            haCruzado = true;
            Camera.main.transform.position = destino.position;
        }
        else
        {
            haCruzado = false;
            Camera.main.transform.position = origen.position;
        }
        colision.enabled = false;
        temporizador = 2.0f;
    }
}
