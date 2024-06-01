using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : InventorySlot
{
    [SerializeField] private ItemType _slotType;
    [SerializeField] private Image _slotHint;
    
    protected override void Update()
    {
        base.Update();
        _slotHint.enabled = IsEmpty;
    }
    
    public override void OnDrop(PointerEventData eventData)
    {
        Item item = eventData.pointerDrag.GetComponent<Item>();
        if (item.ItemInfo.ItemType == _slotType) base.OnDrop(eventData);
    }
}
