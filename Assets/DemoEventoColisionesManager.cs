using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DemoEventoColisionesManager : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters
    
    [Obsolete]
    string tagFiltrado;
    public List<string> tagFiltrados;
    [Obsolete("Se cambio por Lista de objetos detectados")]
    GameObject objetoDetectado;
    public List<GameObject> objetosDetectados;

    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void OnTriggerEnter(Collider collider)
    {
        // if(collider.gameObject.tag == tagFiltrado)
        // {
        //     objetoDetectado = collider.gameObject;
        //     events.onTriggerEnter.Invoke(collider);
        // }

        foreach(string t in tagFiltrados)
        {
            if(EsObjetoFiltrado(collider.gameObject, t))
            {
                objetosDetectados.Add(collider.gameObject);

                events.onTriggerEnter.Invoke(collider);
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        // if(collider.gameObject.tag == tagFiltrado)
        // {
        //     events.onTriggerStay.Invoke(collider);
        // }
        
        foreach(string t in tagFiltrados)
        {
            if(EsObjetoFiltrado(collider.gameObject, t))
            {
                events.onTriggerStay.Invoke(collider);
            }
        } 
    }

    void OnTriggerExit(Collider collider)
    {
        // if(collider.gameObject.tag == tagFiltrado)
        // {
        //     events.onTriggerExit.Invoke(collider);
        //     objetoDetectado = null;
        // }

        foreach(string t in tagFiltrados)
        {
            if(EsObjetoFiltrado(collider.gameObject, t))
            {
                events.onTriggerExit.Invoke(collider);

                objetosDetectados.Remove(collider.gameObject);
            }
        }   
    }
	
    #endregion

    ///////////////////////////////////////////

    #region Methods

    public bool EsObjetoFiltrado(GameObject nuevoObjeto, string tag)
    {
        if(nuevoObjeto.tag == tag)
            return true;

        return false;
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
    
    public Events events;

    #endregion
    
    ///////////////////////////////////////////
    
    #region Data Definitions
    
    [System.Serializable]
    public struct Events
    {
        public UnityEvent<Collider> onTriggerEnter;
        public UnityEvent<Collider> onTriggerStay;
        public UnityEvent<Collider> onTriggerExit;
    }

    #endregion
    
    ///////////////////////////////////////////
}