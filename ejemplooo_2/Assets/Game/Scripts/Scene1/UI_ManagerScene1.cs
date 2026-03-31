using System.Collections;
using TMPro;
using UnityEngine;

public class UI_ManagerScene1 : MonoBehaviour
{

    [Header("Total_Frutas")]
    [SerializeField] private TextMeshProUGUI txtTotalFrutas;

    [Header("Fruta_Recolectada")]
    [SerializeField] private TextMeshProUGUI txtNotificacion;
    [SerializeField] private float duracionNotificacion = 2f;




    void Start()
    {
        if (txtTotalFrutas != null) ;
        txtNotificacion.gameObject.SetActive(false);


    }

    
    public void ActualizarConteoFrutas()
    {
        txtTotalFrutas.text = "Frutas:" + GameManager.Instance.TotalFrutas.ToString();
    }
    
    public void MostrarNotificacion(string nombre, int valor)
    {
        if(txtNotificacion == null) return;
        StopAllCoroutines();
        StartCoroutine(Mostrar_y_Ocultar(nombre, valor));
    }
    

    private IEnumerator Mostrar_y_Ocultar(string nombre, int valor)
    {
        txtNotificacion.text = nombre + " +" + valor.ToString();
        txtNotificacion.gameObject.SetActive(true);
        yield return new WaitForSeconds(duracionNotificacion);
        txtNotificacion.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
