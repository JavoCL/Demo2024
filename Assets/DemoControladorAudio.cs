using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DemoControladorAudio : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters
    
    public AudioMixer audioMixer;

    [Header("Niveles de volumen")]
    [Range(0.0001f, 1f)]
    public float nivelMaster;

    public float temp;

    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        // audioMixer.GetFloat("MasterVolume", out temp);

        // ColorLog("VOLUMEN DE MASTER: " + temp, Color.green);

        GetVolumen();
        ColorLog("VOLUMEN DE MASTER: " + temp, Color.green);
    }

    void Update()
    {
        SetVolumen("MasterVolume", nivelMaster);
    }
	
    #endregion

    ///////////////////////////////////////////

    #region Methods

    public void SetVolumen(string paramExpuesto, float value)
    {
        audioMixer.SetFloat(paramExpuesto, Mathf.Log10(value)*20 );
    }

    public void GetVolumen()
    {
        audioMixer.GetFloat("MasterVolume", out temp);
        nivelMaster = Mathf.Pow(10, temp*20);
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