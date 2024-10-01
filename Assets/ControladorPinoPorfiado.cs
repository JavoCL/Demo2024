using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorPinoPorfiado : MonoBehaviour
{
    public Animator animatorPino;
    public InputActionReference inputMovimiento;

    [Range(-1f,1f)]
    public float adelante;
    [Range(-1f,1f)]
    public float derecha;

    public Vectores vectores;
    // Start is called before the first frame update
    void Start()
    {
        vectores = new Vectores();

        vectores.direccionMovimiento2D = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        vectores.direccionMovimiento2D = inputMovimiento.action.ReadValue<Vector2>();
        // (1,0,1)
        adelante = vectores.direccionMovimiento2D.y;
        derecha = vectores.direccionMovimiento2D.x;

        animatorPino.SetFloat("adelante", adelante);
        animatorPino.SetFloat("derecha", derecha);
    }

    [System.Serializable]
    public struct Vectores
    {
        public Vector2 direccionMovimiento2D;
    }
}
