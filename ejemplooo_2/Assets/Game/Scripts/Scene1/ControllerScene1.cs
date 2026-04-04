using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class ControllerScene1 : MonoBehaviour
{

    [Header("Timer")]
    [SerializeField] private Timer tiempoJuego;

    [Header("UI Manager")]
    [SerializeField] private UI_ManagerScene1 uiManager;

    private const int frutasParaAvanzar = 6;
    private bool escenaCargada = false;

    void Start()
    {
        uiManager.ActualizarConteoFrutas();
        verificarAvance(); 
    }

    void Update()
    {
        uiManager.ActualizarConteoFrutas();
            verificarAvance();
    }

    public void GetTimeScene()
    {
        tiempoJuego.TimerStop();
        GameManager.Instance.TotalTime(tiempoJuego.StopTime);
    }

    private void verificarAvance()
    {
        if (escenaCargada) return;

        if (GameManager.Instance.TotalFrutas >= frutasParaAvanzar)
        {
            escenaCargada=true;
            GetTimeScene(); 
            SceneManager.LoadScene("Scene2");
        }


        

    }
}