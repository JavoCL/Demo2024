using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomAnimationController : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters
    
    public InputActionReference inputMovimiento;
    public Vector2 vectorInputMovimiento;
    public Animator animatorPersonaje;

    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        
    }

    void Update()
    {
        vectorInputMovimiento = inputMovimiento.action.ReadValue<Vector2>();

        animatorPersonaje.SetFloat("forward", vectorInputMovimiento.y);
        animatorPersonaje.SetFloat("right", vectorInputMovimiento.x);
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