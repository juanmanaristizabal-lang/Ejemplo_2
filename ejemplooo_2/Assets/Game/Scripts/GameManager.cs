using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private float globalTime;

    private int totalApple = 0;
    private int totalOrange = 0;    

    

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

    public void TotalItem(ItemData item)
    {
        switch(item.itemType)
        {
            case ItemType.Apple:
                totalApple += item.ItemValue;
                break;
            case ItemType.Orange:
                totalOrange += item.ItemValue;
                break;
        }
    }
    

    public float GlobalTime { get => globalTime; set => globalTime = value; }
    public int TotalApple { get => totalApple; set => totalApple = value; }
    public int TotalOrange { get => totalOrange; set => totalOrange = value; }
}
