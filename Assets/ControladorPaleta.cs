using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorPaleta : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters
    
    public Transform paleta;
    public float minRango;
    public float maxRango;

    public float velocidadGiro = 1000f;
    public float fuerza = 100f;

    public InputActionReference inputPaleta;
    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        
    }

    void Update()
    {
        if(inputPaleta.action.IsPressed() == true)
        {
            Vector3 newEuler = paleta.localEulerAngles;

            if(newEuler.y < maxRango)
                newEuler += new Vector3(0f, Time.deltaTime*velocidadGiro , 0f);
            else
                newEuler = new Vector3(newEuler.x, maxRango , newEuler.z);
            
            paleta.localEulerAngles = newEuler;
        }
        else if(paleta.localEulerAngles.y > minRango)
        {
            Vector3 newEuler = paleta.localEulerAngles;

            if(newEuler.y > minRango)
                newEuler -= new Vector3(0f, Time.deltaTime*velocidadGiro*3f , 0f);
            else
                newEuler = new Vector3(newEuler.x, minRango , newEuler.z);
            
            paleta.localEulerAngles = newEuler;
        }
    }
	
    #endregion

    ///////////////////////////////////////////

    #region Methods
    public void AlColisionarBola(Collision collision)
    {
        if(collision.gameObject.tag == "Bola")
        {
            Rigidbody rbBola = collision.gameObject.GetComponent<Rigidbody>();

            rbBola.AddForce(Vector3.forward * fuerza, ForceMode.Impulse);
        }
    }
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