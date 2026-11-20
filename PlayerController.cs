using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerController : MonoBehaviour
{
    public float velocidad;

    Vector3 movimiento;
    Animator anim;

    public float distCaja;
    public Vector2 tamannoCaja;
    public LayerMask capaSuelo;
    bool saltando;
    SpriteRenderer sprite;
    Rigidbody2D cuerpo;
    int vidaRestante;
    public float fuerzaSalto;
    public int vidaMax;

    // Start is called before the first frame update
    void Start()
    {
        movimiento = new Vector3();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        cuerpo = GetComponent<Rigidbody2D>();
        vidaRestante = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        RotarPersonaje();
        ActualizarAnimacion();
        LeerSalto();
        LeerMovimiento();
    }

    private void LeerMovimiento()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Izquierda
            movimiento = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Derecha
            movimiento = Vector3.right;
        }
        else
        {
            movimiento = new Vector3();
        }
    }

    private void LeerSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !saltando && EstaEnElSuelo())
        {
            saltando = true;
        }
    }

    void FixedUpdate()
    {
        cuerpo.velocity = new Vector2(movimiento.x * velocidad, cuerpo.velocity.y);
        if (saltando)
        {
            cuerpo.AddForce(Vector2.up * fuerzaSalto);
            saltando = false;
        }
    }

    bool EstaEnElSuelo()
    {
        RaycastHit2D rc = Physics2D.BoxCast(transform.position, tamannoCaja, 0, Vector2.down, distCaja, capaSuelo);
        if (rc)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void ActualizarAnimacion()
    {
        if (movimiento.x == 0)
        {
            anim.SetBool("Movimiento", false);
        }
        else
        {
            anim.SetBool("Movimiento", true);
        }
        if (!EstaEnElSuelo())
        {
            anim.SetBool("Salto", true);
        }
        else
        {
            anim.SetBool("Salto", false);
        }
    }

    private void RotarPersonaje()
    {
        if (movimiento.x < 0)
        {
            sprite.flipX = true;
        }
        else if (movimiento.x > 0)
        {
            sprite.flipX = false;
        }
    }

    void OnDrawGizmos()
    {
        if (EstaEnElSuelo())
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireCube(transform.position + Vector3.down * distCaja, tamannoCaja);
        Gizmos.color = Color.white;
    }

    public void RecibeDanno(int cuanto, Vector2 posEnemigo)
    {
        vidaRestante -= cuanto;
        Debug.Log("Ouch!! Vida restante: " + vidaRestante);
    }
    void OnMouseDrag()
    {
        Vector3 mouseWP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector3(mouseWP.x, mouseWP.y, gameObject.transform.position.z);
    }
}
