using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventosInteraccion : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters
    
    [SerializeField]
    private bool _interactuando;
    public bool interactuando
    {
        get{return _interactuando;}
        set
        {
            if(value != _interactuando)
            {
                _interactuando = value;

                if(_interactuando == true)
                    events.alInteractuar.Invoke();
            }
        }
    }

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
    
    public Events events;

    #endregion
    
    ///////////////////////////////////////////
    
    #region Data Definitions
    
    [System.Serializable]
    public struct Events
    {
        public UnityEvent alInteractuar;
    }

    #endregion
    
    ///////////////////////////////////////////
}