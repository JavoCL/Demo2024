using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DemoRaycast : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters

    public Transform origin;
    public float distanciaVista = 10f;
    public string tagObjetoTarget;

    public UnityEvent<Transform> alChocarRaycast;
    public UnityEvent alNoChocarRaycast;
    
    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 direccionRaycast = origin.forward;
        Vector3 direccionLinea = origin.forward*distanciaVista + origin.position;

        RaycastHit hit;

        Debug.DrawLine(origin.position, direccionLinea, Color.red);

        if(Physics.Raycast(origin.position, direccionRaycast, out hit, distanciaVista))
        {
            Log("ESTOY MIRANDO " + hit.collider.gameObject.name);
            
            if(hit.collider.gameObject.tag == tagObjetoTarget)
                alChocarRaycast.Invoke(hit.collider.gameObject.transform);
            else
                alNoChocarRaycast.Invoke();
        }
        else
        {
            Log("NO ESTOY MIRANDO NADA");
            alNoChocarRaycast.Invoke();
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