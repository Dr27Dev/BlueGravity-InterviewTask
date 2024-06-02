using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "Inventory Item")]
public class ItemInfo : ScriptableObject
{
    public string Name;
    public int Price;
    public Sprite Sprite;
    public Material Material;
    public RuntimeAnimatorController AnimatorController;
    public ItemType ItemType;
}
public enum ItemType { Hat, Clothes, Underwear }