using UnityEngine;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IDropHandler
{
    public bool IsEmpty;
    protected virtual void Update() => IsEmpty = transform.childCount == 0;

    public virtual void OnDrop(PointerEventData eventData)
    {
        Item item = eventData.pointerDrag.GetComponent<Item>();
        if (!IsEmpty) gameObject.GetComponentInChildren<Item>().transform.SetParent(item.ParentAfterDrag);
        item.ParentAfterDrag = transform;
    }
}
