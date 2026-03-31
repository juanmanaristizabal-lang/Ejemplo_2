using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManagerScene2 : MonoBehaviour
{

    [Header("UI Mision")]
    [SerializeField] private TextMeshProUGUI txtTituloMision;
    [SerializeField] private TextMeshProUGUI txtObjetivos;
    [SerializeField] private TextMeshProUGUI txtVictoria;



    void Start()
    {
        if (txtVictoria != null)
            txtVictoria.gameObject.SetActive(false);
        StartCoroutine(EsperarYMostrar());
    }

    private IEnumerator EsperarYMostrar()
    {
        yield return new WaitUntil(() =>
            MissionManager.Instance != null &&
            MissionManager.Instance.GetMisionActual() != null
        );

        MostrarMision(MissionManager.Instance.GetMisionActual());
    }


    public void MostrarMision(MissionData mision)
    {
        if (mision is null) return; 
        txtTituloMision.text = "Mision: " + mision.Titulo;

        string objetivos = "";
        foreach (MissionObjective obj in mision.objetivos)
        {
            int recolectados = GameManager.Instance.GetConteo(obj.itemName);
            objetivos += obj.itemName + " : " + recolectados.ToString() + " / " + obj.cantidad.ToString() + "\n";
        }
        txtObjetivos.text = objetivos;
    }

    private void ActualizarProgreso()
    {
        if (MissionManager.Instance == null) return; 

        MissionData mision = MissionManager.Instance.GetMisionActual();
        if(mision is null) return;

        string objetivos = "";
        foreach (MissionObjective obj in mision.Objetivos)
        {
            int recolectados = GameManager.Instance.GetConteo(obj.itemName);
            objetivos += obj.itemName + " : " + recolectados.ToString() + " / " + obj.cantidad.ToString() + "\n";
        }

        txtObjetivos.text = objetivos;
        txtTituloMision.text = "Mision: " + mision.Titulo; 
    }

    public void MostrarVictoria()
    {
        if(txtVictoria != null ) 
                txtVictoria.gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        ActualizarProgreso();
    }
}
