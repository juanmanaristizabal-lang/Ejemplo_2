using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable objects/ItemData")]
public class ItemData : ScriptableObject
{
    

    public string itemName;
    public ItemType itemType;
    public int ItemValue;

    [Header("Sonido")]
    public AudioClip collectSound;

}

public enum ItemType
{
   Apple,
   Orange,
   Kiwi,
   Banana,
   Coin,
   Weapon,
   Armor
}