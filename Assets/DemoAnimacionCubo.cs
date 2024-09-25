using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DemoAnimacionCubo : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters
    
    public InputActionReference inputGiroCubo;
    public InputActionReference inputSaltoCubo;
    public Animator animatorCubo;
    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        inputGiroCubo.action.started += GiraCubo;
        inputSaltoCubo.action.started += SaltaCubo;
    }

    void OnDisable()
    {
        inputGiroCubo.action.started -= GiraCubo;
        inputSaltoCubo.action.started -= SaltaCubo;
    }

    private void SaltaCubo(InputAction.CallbackContext context)
    {
        animatorCubo.SetTrigger("rebota");
    }

    private void GiraCubo(InputAction.CallbackContext context)
    {
        animatorCubo.SetTrigger("gira");
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