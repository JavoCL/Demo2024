using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorCubo : MonoBehaviour
{
    public string cadena = "SOY EL PROFE";
    public int entero;
    public float flotante;
    public float timer = 0f;
    [SerializeField]
    private string cadenaPrivada = "ESTAMOS EN CLASE";
    public bool boleana;
    [SerializeField]
    private Sprite sprite;

    public List<string> listaNombres;
    public string[] arrayApellidos;
    public EstadoAvion estadoAvion;

    public ItemInventario itemInventario;

    public List<ItemInventario> listaItems;
    // SE EJECUTA EN EL FRAME "-1"
    // Ideal para inicialiaciones obligatorias
    void Awake()
    {
        
    }

    // Start is called before the first frame update
    /// Ideal para inicializaciones que dependen de otros anteriores 
    /// (y esos inciados en su Awake)
    void Start()
    {
        Debug.Log("HOLA MUNDO. " + cadena);
    }

    // Se llama antes de cada Frame actualizado/animacion calculada 
    void Update()
    {
        Debug.Log("HOLA MUNDO DE NUEVO (Y VARIAS VECES). " + cadena);
        Debug.Log(cadenaPrivada);
        timer += Time.deltaTime;
    }

    /// Se llama antes de cada actualizacion FISICA
    /// (mas preciso en calculos fisicos)
    void FixedUpdate()
    {
        
    }

    /// Se llama DESPUES DE UPDATE Y FIXEDUPDATE
    /// Ideal para scripts de seguimientos
    void LateUpdate()
    {

    }

    // Se llama 1 vez, cada vez que el objeto se activa
    void OnEnable()
    {
        Debug.Log("HOLA MUNDO, ME ACTIVE!!");
    }

    // Se llama 1 vez, cada vez que el objeto se desactiva
    void OnDisable()
    {
        Debug.Log("HOLA MUNDO, ME DESACTIVE!!");
    }

    public enum EstadoAvion {aterrizado, volando, despegando, enMantencion}

    [System.Serializable]
    public struct ItemInventario
    {
        public string nombreItem;
        public int cantidad;
        public float costo;
        public bool estaHabilitado;
        public Sprite icono;
    }
}
