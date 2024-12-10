using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DemoVision : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters
    
    public Transform origen;
    public float rangoVision;
    public LayerMask capaVision;
    public Color colorVisible = Color.red;
    public Color colorInvisible = Color.white;

    public int factorRayos = 4;
    public int rayosActivos = 0;

    public int rayosDetectados = 0;

    public UnityEvent<Transform> alDetectarObjetivo;
    public UnityEvent alNoDetectarObjetivo;

    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        if(origen == null)
            origen = this.transform;
    }

    void Update()
    {
        int contadorLocal = 0;
        int contadorLocalDetectados = 0;

        // Emitir los rayos desde origen
        for(int i=-65; i<65; i++)
        {
            if(i%factorRayos == 0)
            {
                Vector3 direccionHorizontal = Quaternion.Euler(0, i, 0) * origen.forward;

                for (int j = -30; j < 30; j++)
                {
                    if(j%factorRayos == 0)
                    {
                        Vector3 direccionVertical = Quaternion.Euler(j, 0, 0) * origen.forward;
                        Vector3 direccionFinal = direccionHorizontal + direccionVertical;

                        RaycastHit hit;

                        if (Physics.Raycast(origen.position, direccionFinal, out hit, rangoVision, capaVision))
                        {
                            Debug.DrawLine(origen.position, origen.position + direccionFinal.normalized * rangoVision, colorVisible);
                            contadorLocalDetectados++;
                            alDetectarObjetivo.Invoke(hit.collider.gameObject.transform);
                        }
                        else
                        {
                            Debug.DrawLine(origen.position, origen.position + direccionFinal.normalized * rangoVision, colorInvisible);
                        }

                        contadorLocal++;
                    }
                }
            }
        }

        rayosActivos = contadorLocal;
        rayosDetectados = contadorLocalDetectados;

        if(rayosDetectados == 0)
            alNoDetectarObjetivo.Invoke();
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