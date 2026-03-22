using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] private ItemData _itemData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.TotalItem(_itemData);
            Debug.Log($"Recolectaste un {_itemData.itemType} con valor de {_itemData.ItemValue}");
            Destroy(gameObject);
        }
    }


}
