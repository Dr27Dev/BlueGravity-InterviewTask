using UnityEngine;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IDropHandler
{
    public SlotType SlotType;
    public bool IsEmpty;

    [HideInInspector] public Item PreviouslyHeldItem;
    public Item HeldItem;
    
    protected virtual void Update() => IsEmpty = transform.childCount == 0;

    public virtual void OnDrop(PointerEventData eventData)
    {
        Item item = eventData.pointerDrag.GetComponent<Item>();
        if (!IsEmpty)
        {
            PreviouslyHeldItem = GetComponentInChildren<Item>();
            PreviouslyHeldItem.transform.SetParent(item.ParentBeforeDrag);
        }
        item.ParentAfterDrag = transform;
        HeldItem = item;
    }
}
public enum SlotType { Equipment, Inventory, Shop }
