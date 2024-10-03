using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploControladorCorrutinas : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters
    
    [SerializeField]
    private bool Bandera_;
    public bool bandera
    {
        get
        {
            return Bandera_;
        }
        set
        {
            bool localValue = value;

            Bandera_ = value;
            Log("LA VARIABLE CAMBIO");

            if(localValue == true)
            {
                StartCoroutine(_AlSerTrue());
            }

        }
    }
    
    public bool banderin;
    
    public float tiempo = 0f;
    public float subTimerBandera = 0f;

    public Animator animatorCubo;
    public float normalizedTime;

    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        // StartCoroutine(_CorrutinaEjemplo());
        // StartCoroutine(_EsperaAnimacion());
        StartCoroutine(_ModificaBandera());
    }

    void Update()
    {
        tiempo += Time.deltaTime;
        normalizedTime = animatorCubo.GetCurrentAnimatorStateInfo(0).normalizedTime;
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
	
    IEnumerator _AlSerTrue()
    {
        
        Log("INICIANDO CORRUTINA DESPUES DE BANDERA=TRUE");
        subTimerBandera = 0f;
        while(subTimerBandera <= 5f)
            subTimerBandera += Time.deltaTime;

        Log("TERMINO SUBTIMER DE 5 SEGUNDOS");
        yield return new WaitForSeconds(2f);
        ColorLog("ADIOS!", Color.red);
        bandera = false;
    }

    IEnumerator _ModificaBandera()
    {
        yield return new WaitForSeconds(5f);
        bandera = true;
    }
    IEnumerator _CorrutinaEjemplo()
    {
        yield return null;

        ColorLog("INICIANDO CONTEO DE 3 SEGUNDOS DE ESPERA", Color.green);
        yield return new WaitForSeconds(3f);
        ColorLog("TERMINO LA ESPERA", Color.red);

        yield return new WaitWhile(()=> tiempo < 10f);
        ColorLog("PASAMOS EL LIMITE DE 10 SEGUNDOS", Color.blue);

        yield return new WaitUntil(()=> tiempo >= 20f);
        ColorLog("PASAMOS LA BARRERA DE LOS 20 SEGUNDOS", Color.yellow);
    }

    IEnumerator _EsperaAnimacion()
    {
        yield return new WaitWhile(()=> animatorCubo.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f);
        ColorLog("LA ANIMACION TERMINO", Color.magenta);
    }

    public bool enEjecucion;
    IEnumerator _MobBehaviour()
    {
        yield return null;


        while(enEjecucion == true)
        {
            yield return null;
            //////
            ///



        }
    }

    #endregion
	
    ///////////////////////////////////////////

    #region Events
    
    #endregion
    
    ///////////////////////////////////////////
    
    #region Data Definitions
    
    #endregion
    
    ///////////////////////////////////////////
}