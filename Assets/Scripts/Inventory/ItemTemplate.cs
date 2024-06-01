using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "Inventory Item")]
public class ItemTemplate : ScriptableObject
{
    public float Price;
    public Sprite Sprite;
    public ItemType ItemType;
}
public enum ItemType { Hat, Clothes, Underwear }