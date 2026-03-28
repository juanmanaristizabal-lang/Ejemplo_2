using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private float globalTime;
    private int totalFrutas;

    private Dictionary<string,int> conteoFrutas = new Dictionary<string, int>();

    public float GlobalTime { get => globalTime; set => globalTime = value; }
    public int TotalFrutas { get => totalFrutas; set => totalFrutas = value; }

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
        totalFrutas = 0;
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
        totalFrutas++;
        if(conteoFrutas.ContainsKey(item.Nombre))
        {
            conteoFrutas[item.Nombre]+=1;
        }
        else
        {
            conteoFrutas[item.Nombre] = 1;
        }
    }


    public int GetConteo(string nombre)
    {
        if(conteoFrutas.ContainsKey(nombre))
            return conteoFrutas[nombre];
        return 0;
    }

    public void ResetConteo()
    {
        conteoFrutas.Clear();
        totalFrutas=0;
    }

   
}
