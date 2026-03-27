using UnityEngine;

public class ItemRecolectable : MonoBehaviour
{
    [SerializeField] private string itemNombre;

    [Header("Sonido")]
    [SerializeField] private AudioClip collectSound;


    public void SetItemNombre(string nombre)
    {
        itemNombre = nombre;
    }

    void Start()
    {
        ItemDataJson data = JsonLoader.Instance.GetItem(itemNombre);

        if (data != null)
        {
            Sprite sprite = Resources.Load<Sprite>(data.imagen);
            if (sprite != null)
                GetComponent<SpriteRenderer>().sprite = sprite;
            else
                Debug.LogError($"No se encontró el sprite '{data.imagen}' en Resources");
        }
        else
        {
            Debug.LogError($"No se encontró '{itemNombre}' en el JSON");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ItemDataJson data = JsonLoader.Instance.GetItem(itemNombre);

            if (data != null)
            {
                if (collectSound != null)
                    AudioSource.PlayClipAtPoint(collectSound, transform.position);

                GameManager.Instance.TotalItemJson(data);
                Debug.Log($"Recolectaste un {data.nombre} con valor {data.valor}");
            }

            Destroy(gameObject);
        }
    }
}