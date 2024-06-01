using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "Inventory Item")]
public class ItemInfo : ScriptableObject
{
    public float Price;
    public Sprite Sprite;
    public Material Material;
    public AnimatorController AnimatorController;
    public ItemType ItemType;
}
public enum ItemType { Hat, Clothes, Underwear }