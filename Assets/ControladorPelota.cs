using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorPelota : MonoBehaviour
{
    public InputActionReference inputMovimiento;
    public Vector2 direccionMovimiento2D;
    public Vector3 direccionMovimiento3D;

    public float coeficienteFuerza = 0f;

    public Rigidbody rigidbody3D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody3D = this.gameObject.GetComponent<Rigidbody>();

        direccionMovimiento2D = new Vector2();
        direccionMovimiento3D = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        direccionMovimiento2D = inputMovimiento.action.ReadValue<Vector2>();
        direccionMovimiento3D = ReorganizaVector2(direccionMovimiento2D);
    }

    void FixedUpdate()
    {
        rigidbody3D.AddForce(direccionMovimiento3D * coeficienteFuerza);
    }

    public Vector3 ReorganizaVector2(Vector2 vector2)
    {
        Vector3 newVector = new Vector3(vector2.x, 0f, vector2.y);

        return newVector;
    }
}
