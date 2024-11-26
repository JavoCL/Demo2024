using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPuntuador : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters
    
    public int puntosOtorgados = 10;
    public float fuerza = 5f;

    public ControladorPinball controladorPinball;

    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        
    }

    void Update()
    {
        
    }
	
    #endregion

    ///////////////////////////////////////////

    #region Methods

    public void ImpulsaBolaPuntuada(Collision collision)
    {
        Rigidbody rbBola = collision.gameObject.GetComponent<Rigidbody>();

        rbBola.AddForce(VectorRebote(collision).normalized * fuerza, ForceMode.Impulse);
        // rbBola.AddForce(-collision.transform.forward * fuerza, ForceMode.Impulse);

        controladorPinball.IncrementaPuntos(puntosOtorgados);
    }

    public Vector3 VectorRebote(Collision collision)
    {
        // Vector de movimiento inicial
        Vector3 vectorInicial = collision.gameObject.GetComponent<Rigidbody>().velocity;
        // Vector normal de la superficie de colision
        Vector3 vectorNormal = collision.contacts[0].normal;
        // Refleja el vector inicial en el eje marcado por el vectorNormal
        Vector3 vectorReflejo = Vector3.Reflect(vectorInicial,vectorNormal);

        return vectorReflejo;
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