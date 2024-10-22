using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomAnimationController : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters
    
    public InputActionReference inputMovimiento;
    public InputActionReference inputAgacharse;
    public InputActionReference inputAtaque;
    public InputActionReference inputBloqueo;

    public InputActionReference inputEnGuardia;
    public Vector2 vectorInputMovimiento;
    public Animator animatorPersonaje;

    public ThirdPersonController thirdPersonController;

    public bool estaBloqueando = false;
    public bool agachado = false;
    public bool puedeSaltarAgachado = false;

    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        inputAgacharse.action.started += Agacharse;
        inputAtaque.action.started += Ataca;
        inputBloqueo.action.started += Bloquea;
        // inputAtaque.action.performed += NormalizaAtaque;
    }

    private void Bloquea(InputAction.CallbackContext context)
    {
        estaBloqueando = true;
        animatorPersonaje.SetBool("bloqueando", true);
    }

    private void Ataca(InputAction.CallbackContext context)
    {
        if(estaBloqueando == false)
            animatorPersonaje.SetTrigger("atacando");
    }

    private void Agacharse(InputAction.CallbackContext context)
    {
        if(thirdPersonController.Grounded == true)
        {
            agachado = !agachado;

            if(puedeSaltarAgachado == false)
            {
                thirdPersonController.puedeSaltar = !agachado;
                thirdPersonController.ResetJumpState();
            }
        }
    }

    void Update()
    {
        vectorInputMovimiento = inputMovimiento.action.ReadValue<Vector2>();

        animatorPersonaje.SetFloat("forward", vectorInputMovimiento.y);
        animatorPersonaje.SetFloat("right", vectorInputMovimiento.x);
        
        animatorPersonaje.SetBool("agachado", agachado);

        if(inputBloqueo.action.IsPressed() == false)
        {
            animatorPersonaje.SetBool("bloqueando", false);
            estaBloqueando = false;
        }

        if(inputEnGuardia.action.IsPressed() == true)
        {
            float layerWeight = animatorPersonaje.GetLayerWeight(1); 
            if(layerWeight < 1f)
            {
                layerWeight += Time.deltaTime*3;
                animatorPersonaje.SetLayerWeight(1, layerWeight);
            }
            else
                animatorPersonaje.SetLayerWeight(1, 1f);
        }
        else
        {
            float layerWeight = animatorPersonaje.GetLayerWeight(1); 
            if(layerWeight > 0)
            {
                layerWeight -= Time.deltaTime*6;
                animatorPersonaje.SetLayerWeight(1, layerWeight);
            }
            else
                animatorPersonaje.SetLayerWeight(1, 0f);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "obstaculoAlto")
        {
            Log("EL PERSONAJE CHOCO CON ALGO!: " + hit.gameObject.name);
            animatorPersonaje.SetTrigger("chocando");
        }
    }
	
    #endregion

    ///////////////////////////////////////////

    #region Methods

    #endregion

    ///////////////////////////////////////////

    #region Utils

    public void Log(string message)
    {
        Debug.Log(message);
    }

    public void ErrorLog(string message)
    {
        Debug.LogError(message);
    }

    public void OrderLog(int i)
    {
        Debug.Log("ORDEN: " + i + " || " + this.GetType().ToString());
    }

    public void ColorLog(string message, Color color)
    {
        Debug.Log(string.Format("<color=#{0:X2}{1:X2}{2:X2}>{3}</color>", (byte)(color.r * 255f), (byte)(color.g * 255f), (byte)(color.b * 255f), message));
    }

    #endregion

    ///////////////////////////////////////////
	
    #region Coroutines
	
    #endregion
	
    ///////////////////////////////////////////

    #region Events
    
    #endregion
    
    ///////////////////////////////////////////
    
    #region Data Definitions
    
    #endregion
    
    ///////////////////////////////////////////
}