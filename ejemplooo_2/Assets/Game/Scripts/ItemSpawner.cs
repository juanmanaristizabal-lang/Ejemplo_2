using Unity.VisualScripting;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{


    [Header("Items Prefabs")]
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject orangePrefab;
    [SerializeField] private GameObject bananaPrefab;
    [SerializeField] private GameObject kiwiPrefab;

    [Header("Cantidad a instanciar")]
    [SerializeField] private int appleCount = 3;
    [SerializeField] private int orangeCount = 2;
    [SerializeField] private int kiwiCount = 3;
    [SerializeField] private int bananaCount = 2;

    [Header("Área de spawn")]
    [SerializeField] private float areaWidth = 10f;   
    [SerializeField] private float areaHeight = 5f;
    

    void Start()
    {
        SpawnItems(applePrefab, appleCount);
        SpawnItems(orangePrefab, orangeCount);
        SpawnItems(kiwiPrefab, kiwiCount);
        SpawnItems(bananaPrefab, bananaCount);

    }

    private void SpawnItems(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            float randomX = Random.Range(-areaWidth / 2, areaWidth / 2);
            float randomY = Random.Range(-areaHeight / 2, areaHeight / 2);
            Vector3 spawnPosicio = transform.position + new Vector3(randomX, randomY, 0);

            Instantiate(prefab, spawnPosicio, Quaternion.identity);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green; 
        Gizmos.DrawWireCube(transform.position, new Vector3(areaWidth, areaHeight, 0));
    }

    
    void Update()
    {
        
    }
}
