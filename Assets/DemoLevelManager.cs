using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DemoLevelManager : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters

    public int puntos = 0;
    public int puntoAGanar = 100;

    public int creditos = 0;
    public bool juegaAlIniciar = false;
    
    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        if(juegaAlIniciar == true)
        {
            creditos = 3;
            EsperaPuntosMaximos();
        }
    }

    void Update()
    {
        
    }
	
    #endregion

    ///////////////////////////////////////////

    #region Methods

    public void IncrementaPuntos(int nuevosPuntos)
    {
        puntos += nuevosPuntos;
    }

    public void RestaCreditos(int aRestar)
    {
        if(creditos > 0)
            creditos -= aRestar;
    }

    public void RestaCreditos1()
    {
        RestaCreditos(1);
    }

    public void EsperaPuntosMaximos()
    {
        StartCoroutine(_EsperaPuntosMaximos());
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
	
    IEnumerator _EsperaPuntosMaximos()
    {
        Log("INICIO EL JUEGO. ESPERANDO PUNTOS MAXIMOS.");
        yield return new WaitUntil(()=> puntos >= puntoAGanar || creditos == 0);
        if(puntos >= puntoAGanar)
        {
            ColorLog("GANE", Color.green);
            events.alGanar.Invoke();
        }
        // else if(creditos == 0)
        else
        {
            ColorLog("PERDI", Color.red);
            events.alPerder.Invoke();
        }

        events.alFinalizar.Invoke();
            
    }
    #endregion
	
    ///////////////////////////////////////////

    #region Events

    public Events events;
    
    #endregion
    
    ///////////////////////////////////////////
    
    #region Data Definitions

    [System.Serializable]
    public struct Events
    {
        public UnityEvent alGanar;
        public UnityEvent alPerder;
        public UnityEvent alFinalizar;
    }
    
    #endregion
    
    ///////////////////////////////////////////
}