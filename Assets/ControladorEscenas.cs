using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorEscenas : MonoBehaviour
{
    public GameObject panelCarga;
    public Slider sliderCarga;
    public Animator animatorCargando;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargaEscena(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void CargaEscenaAsync(int index)
    {
        StartCoroutine(_CargaEscenaAsyc(index));
    }

    IEnumerator _CargaEscenaAsyc(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        panelCarga.SetActive(true);

        while(operation.isDone == false)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            float progreso = Mathf.Clamp01(operation.progress / 0.9f);

            sliderCarga.value = progreso;

            yield return null;
        }
    }

    IEnumerator _CargaEscenaAsync2(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        panelCarga.SetActive(true);
        animatorCargando.gameObject.SetActive(true);

        yield return new WaitUntil(()=> operation.isDone == true);

        panelCarga.SetActive(false);
    }
}
