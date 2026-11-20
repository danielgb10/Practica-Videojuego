using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerEnemigo : MonoBehaviour
{
    public float tiempoPatrulla;
    public float velocidad;
    public Vector2 tamannoAtaque;
    public float distanciaAtaque;
    public LayerMask capaJugador;


    float temporizador;
    int direccion;
    Animator anim;
    SpriteRenderer sprite;
    Rigidbody2D cuerpo;
    bool atacando;
    GameObject aGolpear;


    // Start is called before the first frame update
    void Start()
    {
        direccion = 1;
        anim = GetComponent<Animator>();
        temporizador = tiempoPatrulla;
        sprite = GetComponent<SpriteRenderer>();
        cuerpo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarTemporizador();
        Girar();

        if (DetectarJugador())
        {
            anim.SetBool("Atacar", true);
            atacando = true;
        }
        else
        {
            anim.SetBool("Atacar", false);
            atacando = false;
        }
    }

    private bool DetectarJugador()
    {
        RaycastHit2D rayo = Physics2D.BoxCast(
            transform.position, tamannoAtaque, 0, Vector2.right * (direccion == 0 ? 1 : direccion),
            distanciaAtaque, capaJugador
        );

        if (rayo)
        {
            aGolpear = rayo.rigidbody.gameObject;
            return true;
        }
        else
        {
            aGolpear = null;
        }
        return false;
    }

    private void Girar()
    {
        if (direccion >= 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }

    private void ActualizarTemporizador()
    {
        if (!atacando)
        {
            temporizador -= Time.deltaTime;
        }

        if (temporizador < 0)
        {
            direccion *= -1;
            temporizador = tiempoPatrulla;
        }
    }

    void FixedUpdate()
    {
        if (atacando)
        {
            cuerpo.velocity = new Vector2(0, cuerpo.velocity.y);
        }
        else
        {
            cuerpo.velocity = new Vector2(direccion * velocidad, cuerpo.velocity.y);
        }
    }

    public void Punnalada()
    {
        if (aGolpear != null) aGolpear.GetComponent<PlayerController>().RecibeDanno(1, transform.position);
    }

    void OnDrawGizmos()
    {
        if (DetectarJugador())
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireCube(transform.position + Vector3.right * (direccion == 0 ? 1 : direccion) * distanciaAtaque,
            tamannoAtaque
        );
        Gizmos.color = Color.white;
    }
}