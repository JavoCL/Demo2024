using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorPelota : MonoBehaviour
{
    [Header("CONFIGURACIÓN INPUTACTIONS")]
    public InputActionReference inputMovimiento;

    // [Header("VECTORES DE MOVIMIENTO")]
    // public Vector2 direccionMovimiento2D;
    // public Vector3 direccionMovimiento3D;

    [Header("VECTORES DE MOVIMIENTO")]
    public Vectores vectores;

    [Header("MISCELANEO")]
    [Tooltip("Esta fue una variable de ejemplo para la clase. No se utiliza")]
    public string variableDeEjemplo;

    [Header("CONFIGURACIÓN FÍSICA")]
    public float coeficienteFuerza = 0f;
    public Rigidbody rigidbody3D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody3D = this.gameObject.GetComponent<Rigidbody>();

        vectores = new Vectores();

        vectores.direccionMovimiento2D = new Vector2();
        vectores.direccionMovimiento3D = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        vectores.direccionMovimiento2D = inputMovimiento.action.ReadValue<Vector2>();
        vectores.direccionMovimiento3D = ReorganizaVector2(vectores.direccionMovimiento2D);
        // (1,0,1)
    }

    void FixedUpdate()
    {
        // (0,0,1)
        // Vector de magnitud=1, pero que es constante en Z
        // rigidbody3D.AddForce((direccionMovimiento3D + Vector3.forward) * coeficienteFuerza);
        // vector de magnitud=1 apunta hacia adelante del objeto
        rigidbody3D.AddForce((vectores.direccionMovimiento3D + this.transform.forward) * coeficienteFuerza * vectores.direccionMovimiento3D.magnitude);
        Debug.DrawLine(this.transform.position, this.transform.position + rigidbody3D.GetAccumulatedForce(), Color.red);
        Debug.DrawLine(this.transform.position, this.transform.position + rigidbody3D.velocity, Color.green);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Piso")
            Debug.Log("CHOQUE CON ALGO. SE LLAMA '" + collision.gameObject.name + "'");

        if(collision.gameObject.GetComponent<ItemInteractable>() != null)
        {
            Debug.Log("ME PEGUE CON ALGO. ME HICE " + collision.gameObject.GetComponent<ItemInteractable>().cantidadEfecto + " PUNTOS DE DAÑO");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag != "Piso")
            Debug.Log("SIGO CHOCANDO CON ALGO QUE SE LLAMA '" + collision.gameObject.name + "'");
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag != "Piso")
            Debug.Log("DEJE DE CHOCAR CON ALGO QUE SE LLAMABA '" + collision.gameObject.name + "'");
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("ENTRÉ A UN AREA DE NOMBRE '" + collider.name + "'");

        // if(collider.name == "AreaDeDeteccionPuntos")
        //     Debug.Log("1000 PUNTOS A GRIFFINDOR");
        
        // if(collider.name == "AreaDeDeteccionHeal")
        //     Debug.Log("RECUPERASTE 20 PUNTOS DE SALUD");

        if(collider.GetComponent<ItemInteractable>() != null)
        {
            ItemInteractable itemInteractable = collider.GetComponent<ItemInteractable>();
            switch(itemInteractable.tipo)
            {
                case ItemInteractable.TipoInteractable.curaSalud:
                    Debug.Log("RECUPERASTE " + itemInteractable.cantidadEfecto + " PUNTOS DE SALUD");
                    break;
                case ItemInteractable.TipoInteractable.puntos:
                    Debug.Log(itemInteractable.cantidadEfecto + " PUNTOS PARA TI!");
                    break;
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        Debug.Log("SIGO EN UN AREA DE NOMBRE '" + collider.name + "'");
    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log("SALI DE UN AREA DE NOMBRE '" + collider.name + "'");
        // collider.gameObject.SetActive(false);
    }

    public Vector3 ReorganizaVector2(Vector2 vector2)
    {
        Vector3 newVector = new Vector3(vector2.x, 0f, vector2.y);

        return newVector;
    }

    [System.Serializable]
    public struct Vectores
    {
        public Vector2 direccionMovimiento2D;
        public Vector3 direccionMovimiento3D;

        [Header("CONFIGURACIONES DE POSICIONAMIENTO DE LA PELOTA")] // Hipotetico, concepto no utilizado
        // Tener un registro de las posiciones cada 1 segundo (hipotetico, no utilizado)
        public List<Vector3> registroPosiciones;
    }
}
