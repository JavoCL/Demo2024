using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorPinball : MonoBehaviour
{
    public Animator animatorBotonDerecha;
    public Animator animatorBotonIzquierda;
    public InputActionReference inputPivoteDerecha;
    public InputActionReference inputPivoteIzquierda;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        inputPivoteDerecha.action.started += PulsaBotonDerecha;
        inputPivoteDerecha.action.canceled += SueltaBotonDerecha;
    }

    private void SueltaBotonDerecha(InputAction.CallbackContext context)
    {
        animatorBotonDerecha.SetTrigger("soltar");
    }

    void OnDisable()
    {
        inputPivoteDerecha.action.started -= PulsaBotonDerecha;
        inputPivoteDerecha.action.canceled -= SueltaBotonDerecha;
    }

    private void PulsaBotonDerecha(InputAction.CallbackContext context)
    {
        animatorBotonDerecha.SetTrigger("pulsar");
    }
}
