using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private float globalTime;

    private int totalApple = 0;
    private int totalOrange = 0;
    private int totalKiwi = 0;
    private int totalBanana = 0;





    void Awake()
    {
        
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
          
    }


    void Start()
    {
        globalTime = 0;
    }

  
    void Update()
    {
        
    }

    public void TotalTime(float timeScene)
    {
        globalTime += timeScene;
    }

    public void TotalItemJson(ItemDataJson item)
    {
        switch (item.nombre)
        {
            case "Apple":
                totalApple += item.valor;
                break;
            case "Orange":
                totalOrange += item.valor;
                break;
            case "Kiwi":
                totalKiwi += item.valor;
                break;
            case "Banana":
                totalBanana += item.valor;
                break;
        }
    }


    public float GlobalTime { get => globalTime; set => globalTime = value; }
    public int TotalApple { get => totalApple; set => totalApple = value; }
    public int TotalOrange { get => totalOrange; set => totalOrange = value; }
    public int TotalKiwi { get => totalKiwi; set => totalKiwi = value; }
    public int TotalBanana { get => totalBanana; set => totalBanana = value; }
}
