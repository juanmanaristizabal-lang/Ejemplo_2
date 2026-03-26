using UnityEngine;

public class ItemRecolectable : MonoBehaviour
{
    [Header("Tipo de item")]
    [SerializeField] private string itemType;

    [Header("Sonido")]
    [SerializeField] private AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ItemDataJson data = JsonLoader.Instance.GetItem(itemType);

            if (data != null)
            {
                if (collectSound != null)
                    AudioSource.PlayClipAtPoint(collectSound, transform.position);

                GameManager.Instance.TotalItemJson(data);

                Debug.Log($"Recolectaste un {data.nombre} con valor {data.valor}");
            }
            else
            {
                Debug.LogError($"No se encontró el item '{itemType}' en el JSON");
            }

            Destroy(gameObject);
        }
    }
}