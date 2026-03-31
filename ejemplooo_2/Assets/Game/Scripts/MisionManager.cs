using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    private MissionData misionActual;
    private int misionIndex = 1;
    private bool misionCompletada = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        GameManager.Instance.ResetConteo();
        CargarMision(misionIndex);
    }

    private void CargarMision(int id)
    {
        misionActual = JsonLoader.Instance.GetMision(id);
        misionCompletada = false;

        if (misionActual is not null)
            Debug.Log("Mision cargada: " + misionActual.titulo);
        else
            Debug.LogError("No se encontro la mision con id: " + id);
    }

    void Update()
    {
        if (misionActual is null || misionCompletada) return;
        VerificarMision();
    }

    private void VerificarMision()
    {
        foreach (MissionObjective objetivo in misionActual.objetivos)
        {
            int recolectados = GameManager.Instance.GetConteo(objetivo.itemName);
            if (recolectados < objetivo.cantidad)
                return;
        }

        misionCompletada = true;
        OnMisionCompletada();
    }

    private void OnMisionCompletada()
    {
        Debug.Log("Mision completada: " + misionActual.titulo);

        UIManagerScene2 ui = FindFirstObjectByType<UIManagerScene2>();

        if (misionIndex < JsonLoader.Instance.misiones.Count)
        {
            misionIndex++;
            GameManager.Instance.ResetConteo();
            CargarMision(misionIndex);

            if (ui != null)
                ui.MostrarMision(misionActual);
        }
        else
        {
            if (ui != null)
                ui.MostrarVictoria();

            Invoke("IrAScene3", 2f);
        }
    }

    public MissionData GetMisionActual()
    {
        return misionActual;
    }

    private void IrAScene3()
    {
        SceneManager.LoadScene("Scene3");
    }
}


