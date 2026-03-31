using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Panel Instrucciones")]
    [SerializeField] private GameObject panelInstrucciones;

    void Start()
    {
        if (panelInstrucciones != null)
            panelInstrucciones.SetActive(false);
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void MostrarInstrucciones()
    {
        if (panelInstrucciones != null)
            panelInstrucciones.SetActive(true);
    }

    public void CerrarInstrucciones()
    {
        if (panelInstrucciones != null)
            panelInstrucciones.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
