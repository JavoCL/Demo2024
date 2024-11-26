using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ControladorPinball : MonoBehaviour
{

    [Header("CONFIGURACION JUEGO")]

    public bool juegaAlIniciar = false;
    public bool juegoIniciado = false;

    public int creditos = 0;
    public int bolasPorCredito = 3;
    public int bolasRestantes = 0;

    public int puntos;
    public int puntosAGanar = 100;

    [Header("CONFIGURACION ANIMACIONES")]
    public Animator animatorBotonDerecha;
    public Animator animatorBotonIzquierda;

    [Header("CONFIGURACION INPUTS")]
    public InputActionReference inputPivoteDerecha;
    public InputActionReference inputPivoteIzquierda;

    public InputActionReference inputInstanciaBola;

    // Start is called before the first frame update

    [Header("CONFIGURACION BOLA Y PLAYER")]

    public GameObject prefabBola;
    public GameObject currentBola;
    public Transform bolaSpawn;
    public Transform playerPosition;
    public Camera pinballCamera;

    [Header("CONFIGURACION EVENTOS")]

    public Events events;

    void Start()
    {
        if(juegaAlIniciar == true)
        {
            creditos = 1;
            IniciaJuego();

            EsperaPuntosMaximos();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        // inputPivoteDerecha.action.started += PulsaBotonDerecha;
        // inputPivoteDerecha.action.canceled += SueltaBotonDerecha;

        inputInstanciaBola.action.started += InstanciaNuevaBola;
    }

    private void InstanciaNuevaBola(InputAction.CallbackContext context)
    {
        InstanciaBola();
    }

    private void SueltaBotonDerecha(InputAction.CallbackContext context)
    {
        animatorBotonDerecha.SetTrigger("soltar");
    }

    void OnDisable()
    {
        // inputPivoteDerecha.action.started -= PulsaBotonDerecha;
        // inputPivoteDerecha.action.canceled -= SueltaBotonDerecha;

        inputInstanciaBola.action.started -= InstanciaNuevaBola;
    }

    ///////////////////////////////////////////

    #region Methods

    public void IncrementaPuntos(int nuevosPuntos)
    {
        puntos += nuevosPuntos;
    }

    public void RestaCreditos(int aRestar)
    {
        if(creditos > 0)
            creditos -= aRestar;
    }

    public void RestaBola(int aRestar)
    {
        if(bolasRestantes > 0)
            bolasRestantes -= aRestar;
        
        if(bolasRestantes == 0)
            RestaCreditos1();
    }

    public void RestaBola1()
    {
        RestaBola(1);
    }

    public void RestaCreditos1()
    {
        RestaCreditos(1);
    }

    public void EsperaPuntosMaximos()
    {
        StartCoroutine(_EsperaPuntosMaximos());
    }

    public void IniciaJuego()
    {
        juegoIniciado = true;

        bolasRestantes = bolasPorCredito * creditos;
    }

    private void PulsaBotonDerecha(InputAction.CallbackContext context)
    {
        animatorBotonDerecha.SetTrigger("pulsar");
    }

    public void InstanciaBola()
    {
        if(currentBola == null)
        {
            currentBola = GameObject.Instantiate(prefabBola, bolaSpawn);
            currentBola.transform.parent = null;
            // currentBola.name = "SOYUNANUEVABOLA";
            events.alInstanciarBola.Invoke();
        }
    }

    public AudioSource alPerder;

    public void DestruyeCurrentBola()
    {
        GameObject.Destroy(currentBola);
        currentBola = null;
    }

    public void PosicionaPlayer(DemoEventoColisionesManager colisionesManager)
    {
        if(colisionesManager.objetosDetectados != null)
        {
            // Debug.Log("LISTA EXISTE");
            if(colisionesManager.objetosDetectados.Count > 0)
            {
                // Debug.Log("HAY MAS DE UN OBJETO");
                if(colisionesManager.objetosDetectados[0].tag == "Player")
                {
                    // Player detectado
                    // Debug.Log("PLAYER DETECTADO");
                    Animator animatorPlayer = colisionesManager.objetosDetectados[0].GetComponent<Animator>();

                    // Debug.Log("SETEANDO BOOL");
                    animatorPlayer.SetBool("jugandoPinball", !animatorPlayer.GetBool("jugandoPinball"));

                    PinballPlayer player = colisionesManager.objetosDetectados[0].GetComponent<PinballPlayer>();
                    player.CambiaActionMap(animatorPlayer.GetBool("jugandoPinball") == true ? "Pinball" : "Movimiento");

                    if(animatorPlayer.GetBool("jugandoPinball") == true)
                        CentraPlayer(player);
                    else
                    {
                        player.GetComponent<CharacterController>().enabled = true;
                        player.GetComponent<ThirdPersonController>().enabled = true;
                    }

                    player.playerCamera.gameObject.SetActive(!animatorPlayer.GetBool("jugandoPinball"));
                    pinballCamera.gameObject.SetActive(animatorPlayer.GetBool("jugandoPinball"));
                }
            }
        }
    }

    public void CentraPlayer(PinballPlayer player)
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<ThirdPersonController>().enabled = false;

        player.transform.parent = playerPosition;
        player.transform.localPosition = Vector3.zero;
        player.transform.localEulerAngles = Vector3.zero;

        player.transform.parent = null;
    }

    #endregion

    ///////////////////////////////////////////
	
    #region Coroutines
	
    IEnumerator _CentraPlayer(PinballPlayer player)
    {
        player.transform.parent = playerPosition;
        // player.GetComponent<>

        while(player.transform.localPosition != Vector3.zero)
        {
            Vector3.Lerp(Vector3.zero, player.transform.localPosition, Time.deltaTime);
            
            yield return new WaitForSeconds(Time.deltaTime);
        }

        player.transform.parent = null;
    }    
	
    IEnumerator _EsperaPuntosMaximos()
    {
        Debug.Log("INICIO EL JUEGO. ESPERANDO PUNTOS MAXIMOS.");
        yield return new WaitUntil(()=> puntos >= puntosAGanar || creditos == 0);
        if(puntos >= puntosAGanar)
        {
            Debug.Log("GANE");
            events.alGanar.Invoke();
        }
        else
        {
            Debug.Log("PERDI");
            events.alPerder.Invoke();
        }

        events.alFinalizar.Invoke();
            
    }

    #endregion

    ///////////////////////////////////////////

    [System.Serializable]
    public struct Events
    {
        public UnityEvent alIniciar;
        public UnityEvent alGanar;
        public UnityEvent alPerder;
        public UnityEvent alFinalizar;
        public UnityEvent alInstanciarBola;
    }
}
