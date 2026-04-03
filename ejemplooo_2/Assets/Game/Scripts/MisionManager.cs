using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    [Header("Spawner")]
    [SerializeField] private ItemSpawner itemSpawner;

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

        if (misionActual != null)
        {
            Debug.Log("Mision cargada: " + misionActual.titulo);
            itemSpawner.SpawnParaMision(misionActual);
        }
        else
            Debug.LogError("No se encontro la mision con id: " + id);
    }

    void Update()
    {
        if (misionActual == null || misionCompletada) return;
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
            itemSpawner.LimpiarFrutas();
            CargarMision(misionIndex);

            if (ui != null)
                ui.MostrarMision(misionActual);
        }
        else
        {
            if (ui != null)
                ui.MostrarVictoria();

            ControllerScene2 controller = FindFirstObjectByType<ControllerScene2>();
            if (controller != null)
                controller.GetTimeScene();

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