using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    [Header("Prefab genérico")]
    [SerializeField] private GameObject itemPrefab;

    [Header("Puntos de spawn")]
    [SerializeField] private List<Transform> spawnPoints;

    void Start()
    {
        SpawnItems();
    }

    private void SpawnItems()
    {
        if (itemPrefab == null || spawnPoints.Count == 0) return;

        List<ItemDataJson> coleccionables = JsonLoader.Instance.coleccionables;

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            ItemDataJson data = coleccionables[Random.Range(0, coleccionables.Count)];

            GameObject obj = Instantiate(itemPrefab, spawnPoints[i].position, Quaternion.identity);

            obj.GetComponent<ItemRecolectable>().SetItemNombre(data.nombre);
        }
    }



void Update()
    {
        
    }
}
