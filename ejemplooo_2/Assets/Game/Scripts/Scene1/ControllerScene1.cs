using UnityEngine;
using TMPro;

public class ControllerScene1 : MonoBehaviour
{

    public Timer tiempoJuego;

    public TextMeshProUGUI txtCountApple;
    public TextMeshProUGUI txtCountOrange;
    public TextMeshProUGUI txtCountKiwi;
    public TextMeshProUGUI txtCountBanana;



    void Start()
    {
        tiempoJuego.TimerStart();
    }

    // Update is called once per frame
    void Update()
    {
        GetTotalItem();
    }

    public void GetTimeScene() {
 
        GameManager.Instance.TotalTime(tiempoJuego.StopTime);
    }

    public void GetTotalItem()
    {
        txtCountApple.text  =  GameManager.Instance.TotalApple.ToString();
        txtCountOrange.text =  GameManager.Instance.TotalOrange.ToString();
        txtCountKiwi.text   =  GameManager.Instance.TotalKiwi.ToString();
        txtCountBanana.text =  GameManager.Instance.TotalBanana.ToString();
    }

    
}
