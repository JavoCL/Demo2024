using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAnimacionCubo : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters
    
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

    public void CuboEnAlto()
    {
        Log("EL CUBO LLEGO A LO ALTO!");
    }

    public void CuboEnSuelo()
    {
        ColorLog("EL CUBO CAYO AL SUELO!", Color.red);
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