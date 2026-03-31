using UnityEngine;

public class ControllerScene2 : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private Timer tiempoJuego;

    void Start()
    {
        tiempoJuego.TimerStart();
    }

    public void GetTimeScene()
    {
        tiempoJuego.TimerStop();
        GameManager.Instance.TotalTime(tiempoJuego.StopTime);
    }
}
