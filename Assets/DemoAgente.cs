using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class DemoAgente : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters

    public Transform objetivoDetectado;
    public NavMeshAgent agent;
    public Vector3 ultimaUbicacion;

    public Transform currentPatrulla;
    public List<Transform> listaPatrullaje;

    public UnityEvent alDetectarObjetivo;
    public UnityEvent alNoDetectarObjetivo;
    
    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        currentPatrulla = listaPatrullaje[Random.Range(0, listaPatrullaje.Count)];

    }

    public float distancia = 0f;

    void Update()
    {
        float distanciaPatrulla = Vector3.Distance(this.transform.position, currentPatrulla.position);

        if(distanciaPatrulla > 0.1f)
            agent.destination = currentPatrulla.position;
        else
            currentPatrulla = listaPatrullaje[Random.Range(0,listaPatrullaje.Count)];

    }
	
    #endregion

    ///////////////////////////////////////////

    #region Methods

    public void SetAnimacionCorrer(bool estado)
    {
        this.gameObject.GetComponent<Animator>().SetBool("corriendo", estado);
    }

    public void SetObjetivo(Transform nuevoObjetivo)
    {
        objetivoDetectado = nuevoObjetivo;
        ultimaUbicacion = objetivoDetectado.position;
    }

    public void ResetObjetivo()
    {
        objetivoDetectado = null;
        ultimaUbicacion = this.transform.position;
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