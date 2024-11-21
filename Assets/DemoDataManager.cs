using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class DemoDataManager : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters

    public DemoLevelManager levelManager;

    public DataPartida dataPartida;
    public DataPartida dataCargada;

    public string json;
    
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

    public void LlenaData()
    {
        dataPartida.creditos = levelManager.creditos;
        dataPartida.puntos = levelManager.puntos;
        dataPartida.fecha = DateTime.Now.ToString();
    }

    public void LlenaJson()
    {
        LlenaData();

        json = JsonUtility.ToJson(dataPartida);

        Log("JSON GENERADO: " + json);

        LeeJson();
    }

    public void LeeJson()
    {
        dataCargada = JsonUtility.FromJson<DataPartida>(json);
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
    
    [System.Serializable]
    public struct DataPartida
    {
        public int puntos;
        public int creditos;
        public string fecha;
    }

    #endregion
    
    ///////////////////////////////////////////
}