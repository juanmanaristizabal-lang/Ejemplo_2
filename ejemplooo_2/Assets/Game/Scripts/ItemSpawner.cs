using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    [Header("Prefab genérico")]
    [SerializeField] private GameObject itemPrefab;

    [Header("Puntos de spawn")]
    [SerializeField] private List<Transform> spawnPoints;

    [Header("Configuracion")]
    [SerializeField] private bool spawnAutomatico = true; 

    private List<GameObject> frutasActivas = new List<GameObject>();

    void Start()
    {
        if (spawnAutomatico)
            SpawnItems();
    }


    //Sene 1 (Aparece normal)
    private void SpawnItems()
    {
        if (itemPrefab == null || spawnPoints.Count == 0) return;

        List<ItemDataJson> coleccionables = JsonLoader.Instance.coleccionables;

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            ItemDataJson data = coleccionables[Random.Range(0, coleccionables.Count)];

            SpawnFruta(spawnPoints[i].position,data.nombre);
        }
    }

    public void SpawnParaMision(MissionData mision)
    {
        if (itemPrefab == null || spawnPoints.Count == 0) return;

        List<string> frutasGarantizadas = new List<string>();

        foreach (MissionObjective objetivo in mision.objetivos)
        {
            for (int i = 0; i < objetivo.cantidad; i++)
                frutasGarantizadas.Add(objetivo.itemName);
        }

        List<ItemDataJson> coleccionables = JsonLoader.Instance.coleccionables;

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            string nombre;

            if (i < frutasGarantizadas.Count)
                nombre = frutasGarantizadas[i];
            else
                nombre = coleccionables[Random.Range(0, coleccionables.Count)].nombre;

            SpawnFruta(spawnPoints[i].position, nombre);
        }
    }


    private void SpawnFruta(Vector2 posicion, string nombre)
    {
        GameObject fruta = Instantiate(itemPrefab, posicion, Quaternion.identity);
        fruta.GetComponent<ItemRecolectable>().SetItemNombre(nombre);
        frutasActivas.Add(fruta);
    }



    public void LimpiarFrutas()
    {
        foreach(GameObject fruta in frutasActivas)
        {
            if (fruta != null)
                Destroy(fruta);
        }
        frutasActivas.Clear();

    }

    void Update()
    {
        
    }
}
