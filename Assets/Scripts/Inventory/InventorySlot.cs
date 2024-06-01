using UnityEngine;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IDropHandler
{
    public bool IsEmpty;
    protected virtual void Update() => IsEmpty = transform.childCount == 0;

    public virtual void OnDrop(PointerEventData eventData)
    {
        if (IsEmpty)
        {
            GameObject dropped = eventData.pointerDrag;
            Item item = dropped.GetComponent<Item>();
            item.ParentAfterDrag = transform;
        }
    }
}
