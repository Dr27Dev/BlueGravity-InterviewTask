using UnityEngine;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IDropHandler
{
    public SlotType SlotType;
    public bool IsEmpty;
    protected virtual void Update() => IsEmpty = transform.childCount == 0;

    public virtual void OnDrop(PointerEventData eventData)
    {
        Item item = eventData.pointerDrag.GetComponent<Item>();
        if (!IsEmpty) GetComponentInChildren<Item>().transform.SetParent(item.ParentBeforeDrag);
        item.ParentAfterDrag = transform;
    }
}
public enum SlotType { Equipment, Inventory, Shop }
