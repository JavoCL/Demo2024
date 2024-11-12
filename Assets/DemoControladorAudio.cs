using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class DemoControladorAudio : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters
    
    public AudioMixer audioMixer;

    [Header("Niveles de volumen")]
    [Range(0.0001f, 1f)]
    public float nivelMaster;

    public Slider sliderMaster;

    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        // audioMixer.GetFloat("MasterVolume", out temp);

        // ColorLog("VOLUMEN DE MASTER: " + temp, Color.green);

        // GetVolumen();
        // ColorLog("VOLUMEN DE MASTER: " + temp, Color.green);
        // ColorLog("VARIABLE PLAYERPREFS MASTERVOLUMEN: " + PlayerPrefs.GetFloat("MasterVolumen"), Color.green);

        if(PlayerPrefs.HasKey("MasterVolumen") == true)
        {
            nivelMaster = CargaVolumen("MasterVolumen");
        }
        else
        {
            EstableceVolumen("MasterVolumen", nivelMaster);
        }
    }

    void Update()
    {
        // SetVolumen("MasterVolume", nivelMaster);
        // EstableceVolumen("MasterVolumen", nivelMaster);

        //ColorLog("VARIABLE PLAYERPREFS MASTERVOLUMEN: " + PlayerPrefs.GetFloat("MasterVolumen"), Color.green);
    }
	
    #endregion

    ///////////////////////////////////////////

    #region Methods

    public void EstableceVolumen(string paramExpuesto, float valorVolumen)
    {
        float volumen = Mathf.Log10(valorVolumen) * 20f;

        /// Toma valor de 'volumen' en decibelios (entre -80 dB a 0 dB)
        audioMixer.SetFloat(paramExpuesto, volumen);
        PlayerPrefs.SetFloat(paramExpuesto, valorVolumen);
        Log("VALOR VOLUMEN AL GUARDAR " + volumen);
    }

    public void EstableceMaster(float valorVolumen)
    {
        EstableceVolumen("MasterVolumen", valorVolumen);
    }

    public float CargaVolumen(string paramExpuesto)
    {
        float valorVolumen = PlayerPrefs.GetFloat(paramExpuesto);

        if(sliderMaster != null)
            sliderMaster.value = valorVolumen;

        EstableceVolumen(paramExpuesto, valorVolumen);
        return valorVolumen;
    }

    public void SetVolumen(string paramExpuesto, float value)
    {
        audioMixer.SetFloat(paramExpuesto, Mathf.Log10(value)*20 );
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