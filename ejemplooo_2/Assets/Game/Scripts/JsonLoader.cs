using UnityEngine;
using System.IO;
using System.Collections.Generic;
 
public class JsonLoader : MonoBehaviour
{
    public static JsonLoader Instance;
 
    public List<ItemDataJson> coleccionables = new List<ItemDataJson>();
    public List<MissionData>  misiones       = new List<MissionData>();
 
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
 
        Instance = this;
        DontDestroyOnLoad(gameObject);
 
        LoadGameData();
    }
 
    private void LoadGameData()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "gamedata.json");
 
        if (File.Exists(path))
        {
            string json   = File.ReadAllText(path);
            leer_json data = JsonUtility.FromJson<leer_json>(json);
 
            coleccionables = data.coleccionables;
            misiones       = data.misiones;
 
            Debug.Log($"Coleccionables cargados: {coleccionables.Count} | Misiones cargadas: {misiones.Count}");
        }
        else
        {
            Debug.LogError("No se encontró gamedata.json en StreamingAssets");
        }
    }
 
    
    public ItemDataJson GetItem(string nombre)
    {
        return coleccionables.Find(i => string.Equals(i.nombre, nombre, System.StringComparison.OrdinalIgnoreCase));
    }





    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
