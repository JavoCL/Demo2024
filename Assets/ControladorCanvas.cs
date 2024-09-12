using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorCanvas : MonoBehaviour
{
    public TMP_Text textoEditable;
    public TMP_Dropdown dropdown;
    public Toggle toggleEjemplo;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReportaDropdown()
    {
        Debug.Log("LA NUEVA OPCION GRÁFICA ES: " + dropdown.options[dropdown.value].text);
    }

    public void ReportaToggle()
    {
        Debug.Log("RAYTRACING ESTA " + (toggleEjemplo.isOn == true ? "Activado" : "Desactivado"));
    }

    public void AumentaSalud10()
    {
        int salud = int.Parse(textoEditable.text);

        salud += 10;

        textoEditable.text = salud.ToString();
    }

    public void AumentaSalud(int aumento)
    {
        int salud = int.Parse(textoEditable.text);

        salud += aumento;

        textoEditable.text = salud.ToString();
    }

    public void AumentaSalud()
    {
        int salud = int.Parse(textoEditable.text);

        salud += int.Parse(inputField.text);

        textoEditable.text = salud.ToString();
    }
}
