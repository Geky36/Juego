using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.EventSystems;

public class movimiento : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private BoxCollider2D espada;
    [SerializeField] Canvas canvas;

    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spritePersonaje;
    private float posX=1, posY=0;
    private int vidas = 3;

    private void Awake() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spritePersonaje = GetComponentInChildren<SpriteRenderer>();
    }
    private void FixedUpdate() {
        Movimiento();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            anim.SetTrigger("Ataque");
        }
    }

    private void Movimiento() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rig.linearVelocity = new Vector2(horizontal, vertical) * velocidad;
        anim.SetFloat("CAMINAR", Mathf.Abs(rig.linearVelocity.magnitude));

        if (horizontal > 0)
        {
            spritePersonaje.flipX = false;
            espada.offset = new Vector2(posX, posY);
        }
        else if (horizontal < 0)
        {
            spritePersonaje.flipX = true;
            espada.offset = new Vector2(-posX, posY);

        }
    }
}
