using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPokeball : MonoBehaviour
{
    public float velocidadMovimiento = 1f;
    public Vector2 direccionMovimiento;
    public Rigidbody2D rb2D;

    public InputActionReference inputMovimiento;
    public InputActionReference inputFuego;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb2D != null)
            Debug.Log(rb2D.velocity);
        // Debug.Log("ESTO SUCEDE DESPUES DEL LOG DEL RIGIDBODY");

        direccionMovimiento = inputMovimiento.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(direccionMovimiento.x * velocidadMovimiento,
                                direccionMovimiento.y * velocidadMovimiento);
    }

    void OnEnable()
    {
        inputFuego.action.started += Fuego;
    }

    void OnDisable()
    {
        inputFuego.action.started -= Fuego;
    }

    private void Fuego(InputAction.CallbackContext context)
    {
        Debug.Log("FUEGO!! ESTOY DISPARANDO");
    }
}
