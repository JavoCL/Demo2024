using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class DemoDataManager : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters

    public ControladorPinball controladorPinball;

    public DataPartida dataPartida;
    public DataPartida dataCargada;
    public DataPartida dataCargadaArchivo;

    public string json;
    public string ruta;
    
    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        ruta = Application.streamingAssetsPath + "/pinballData.json";

        dataCargadaArchivo = CargaArchivoJson();

        if(controladorPinball.juegaAlIniciar == true)
            CargaDatosPrevios();

    }

    void Update()
    {
        // Log("DATA PATH: " + Application.dataPath);
        // Log("PERSISTENT DATA PATH: " + Application.persistentDataPath);
        // Log("STREAMING ASSET PATH: " + Application.streamingAssetsPath);
    }
	
    #endregion

    ///////////////////////////////////////////

    #region Methods

    public void LlenaData()
    {
        dataPartida.creditos = controladorPinball.creditos;
        dataPartida.puntos = controladorPinball.puntos;
        dataPartida.fecha = DateTime.Now.ToString();
    }

    // Si hay un archivo guardado, se comienza desde ahi
    public void CargaDatosPrevios()
    {
        controladorPinball.puntos = dataCargadaArchivo.puntos;
        controladorPinball.creditos = dataCargadaArchivo.creditos;
    }

    public void LlenaJson()
    {
        LlenaData();

        json = JsonUtility.ToJson(dataPartida);

        Log("JSON GENERADO: " + json);

        LeeJson();
        GuardaArchivoJson();
    }

    public void LeeJson()
    {
        dataCargada = JsonUtility.FromJson<DataPartida>(json);
    }

    public void GuardaArchivoJson()
    {
        File.WriteAllText(ruta, json);
        Log("DATOS GUARDADOS EN: " + ruta);
    }

    public DataPartida CargaArchivoJson()
    {
        DataPartida dataArchivo = new DataPartida();

        if(File.Exists(ruta) == true)
        {
            Log("ARCHIVO EXISTE");
            string jsonAux = File.ReadAllText(ruta);

            dataArchivo = JsonUtility.FromJson<DataPartida>(jsonAux);
        }
        else
            Log("ARCHIVO NO ENCONTRADO EN " + ruta);

        return dataArchivo;
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