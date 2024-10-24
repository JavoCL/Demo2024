using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class DemoEventos : MonoBehaviour
{
    public UnityEvent eventoEjemplo;
    public UnityEvent onFlagVerdadero;

    public UnityEvent<float> eventoParametrizado;

    public Events events;

    public UnityEvent eventoPersonalizado;

    [SerializeField]
    private bool _Flag;
    public bool Flag
    {
        get
        {
            // retorno del valor de la variable privada
            return _Flag;
        }
        set
        {
            /// se asigna valor a la variable privada 
            /// desde el value posterior al signo '='
            _Flag = value;

            if(value == true)
            {
                onFlagVerdadero.Invoke();
                eventoPersonalizado.Invoke();

                eventoPersonalizado.AddListener(MetodoEventoEjemplo);
            }
            else
            {
                eventoParametrizado.Invoke(Time.deltaTime);
            }
        }
    }

    private void MetodoEventoEjemplo()
    {
        /// akjsdkahsbdhasd
        /// ahsdbvash dbs
    }

    public bool SegundaFlag;

    // Start is called before the first frame update
    void Awake()
    {
        eventoEjemplo.AddListener(MensajeInterno);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        eventoEjemplo.Invoke();
    }

    public void Log(string message)
    {
        Debug.Log(message);
    }

    private void MensajeInterno()
    {
        Log("MENSAJE INTERNO");
    }

    public void TiempoUltimoFrame(float tiempo)
    {
        Log("ULTIMO FRAME EJECUTADO EN " + tiempo + " SEGUNDOS");
    }

    void OnCollisionEnter(Collision collision)
    {
        Log("CHOQUE. TAG: " + collision.gameObject.tag);

        events.onCollisionEnter.Invoke(collision);
    }

    

    public void NombreDelAreaIntereactiva(Collision col)
    {
        Log("EL NOMBRE DEL OBJETO ES: " + col.gameObject.name);
    }

[System.Serializable]
    public struct Events
    {
        public UnityEvent<Collider> onTriggerEnter;
        public UnityEvent<Collision> onCollisionEnter;
    }

}
