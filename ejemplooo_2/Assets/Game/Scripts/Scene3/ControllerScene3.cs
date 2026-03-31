using UnityEngine;

public class ControllerScene3 : MonoBehaviour
{
    [Header("UI Manager")]
    [SerializeField] private UImanagerScene3 uiManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.TotalTime(0);
        Debug.Log("Tiempo total de juego: " + GameManager.Instance.GlobalTime.ToString("F2") + " seg");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
    
