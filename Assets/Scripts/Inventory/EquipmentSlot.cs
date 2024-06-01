using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : InventorySlot
{
    [SerializeField] private ItemType _slotType;
    [SerializeField] private Image _slotHint;
    private Item _equippedItem;
    private bool _itemEquipped;

    private void Start() => _itemEquipped = false;

    protected override void Update()
    {
        base.Update();
        _slotHint.enabled = IsEmpty;
        CheckItemStatus();
    }

    private void CheckItemStatus() // Un-equip item
    {
        if (IsEmpty && _itemEquipped)
        {
            CharacterEquipment.Instance.EquipItem(_slotType, _equippedItem.ItemInfo, false);
            _equippedItem = null;
            _itemEquipped = false;
        }
        else if (!IsEmpty) _itemEquipped = true;
    }
    
    public override void OnDrop(PointerEventData eventData)
    {
        Item item = eventData.pointerDrag.GetComponent<Item>();
        if (item.ItemInfo.ItemType == _slotType)
        {
            if (!IsEmpty) gameObject.GetComponentInChildren<Item>().transform.SetParent(item.ParentAfterDrag);
            item.ParentAfterDrag = transform;
            EquipItem(item);
        }
    }

    public void EquipItem(Item item)
    {
        _equippedItem = item;
        CharacterEquipment.Instance.EquipItem(_slotType, _equippedItem.ItemInfo, true);
    }
}
