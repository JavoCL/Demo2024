using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ControladorPinball : MonoBehaviour
{
    public Animator animatorBotonDerecha;
    public Animator animatorBotonIzquierda;
    public InputActionReference inputPivoteDerecha;
    public InputActionReference inputPivoteIzquierda;

    public InputActionReference inputInstanciaBola;

    // Start is called before the first frame update

    public GameObject prefabBola;
    public GameObject currentBola;
    public Transform bolaSpawn;
    public Transform playerPosition;
    public Camera pinballCamera;

    public Events events;

    void Start()
    {
        
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

        // alPerder.Play();
        // alPerder.Stop();
        // alPerder.clip = // EL ARCHIVO .MP3 O .WAV
        // alPerder.clip.length 
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

    [System.Serializable]
    public struct Events
    {
        public UnityEvent alInstanciarBola;
    }
}
