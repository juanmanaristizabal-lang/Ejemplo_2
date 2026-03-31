using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanagerScene3 : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI txtVictoria;
    [SerializeField] private TextMeshProUGUI txtTiempoTotal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txtVictoria.text = "!Felicidades Completaste todas las misiones";
        txtTiempoTotal.text = "Tiempo total: " + GameManager.Instance.GlobalTime.ToString("F2") + " seg ";
    }


    public void VolverAlMenu() {
        SceneManager.LoadScene("Menu_Intro"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
