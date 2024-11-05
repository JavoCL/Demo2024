using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PinballPlayer : MonoBehaviour
{
    public Camera playerCamera;
    public PlayerInput playerInput;

    public List<InputActionReference> inputsInteractuar;

    public string ultimoActionMap;

    public bool enAreaInteractiva = false;
    public EventosInteraccion currentInteraccion = null;

    public UnityEvent alInteractuar;

    void OnEnable()
    {
        foreach(InputActionReference i in inputsInteractuar)
        {
            i.action.started += Interactuar;
        }
    }

    void OnDisable()
    {
        foreach(InputActionReference i in inputsInteractuar)
        {
            i.action.started -= Interactuar;
        }
    }

    private void Interactuar(InputAction.CallbackContext context)
    {
        if(currentInteraccion != null)
        {
            // CambiaActionMap();
            // alInteractuar.Invoke();

            DetectaAreaInteractiva();
        }
            
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ACTION MAP ACTUAL: " + playerInput.currentActionMap.name);
        ultimoActionMap = playerInput.currentActionMap.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiaActionMap()
    {
        if(playerInput.currentActionMap.name == "Movimiento")
            playerInput.SwitchCurrentActionMap("Pinball");
        else if(playerInput.currentActionMap.name == "Pinball")
            playerInput.SwitchCurrentActionMap("Movimiento");

        Debug.Log("ACTION MAP ACTUAL: " + playerInput.currentActionMap.name);
    }

    public void CambiaActionMap(string newActionMap)
    {
        playerInput.SwitchCurrentActionMap(newActionMap);
    }

    public void EstableceEstadoAreaInteractiva(bool estado)
    {
        enAreaInteractiva = estado;
    }

    public void DetectaInteraccion(Collider collider)
    {
        currentInteraccion = collider.GetComponent<EventosInteraccion>();
    }

    public void DetectaAreaInteractiva()
    {
        if(currentInteraccion.gameObject.tag == "areaInteractiva")
        {
            currentInteraccion.interactuando = true;
            currentInteraccion.interactuando = false;
        }
    }

    public void ResetInteraccion(Collider collider)
    {
        currentInteraccion = null;
    }
}
