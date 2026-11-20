using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class ScriptPuerta : MonoBehaviour
{
    public GameObject[] listaBotones;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int contador = 0;
        foreach (GameObject go in listaBotones)
        {
            IPulsable scr = go.GetComponent<IPulsable>();
            if (scr.EstaPulsado())
            {
                contador++;
            }

            //contador += go.GetComponent<ScriptBoton>().EstaPulsado ? 1 : 0;
        }

        SpriteRenderer dibujo = GetComponent<SpriteRenderer>();
        BoxCollider2D colision = GetComponent<BoxCollider2D>();

        if (contador == listaBotones.Length)
        {
            //this.gameObject.SetActive(false);
            dibujo.enabled = false;
            colision.enabled = false;
        }
        else
        {
            //gameObject.SetActive(true);
            dibujo.enabled = true;
            colision.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pulsados " + contador + " botones");
        }
        //for (int i = 0; i < listaBotones.Length; i++)
        //{

        //}
    }
}
