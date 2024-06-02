using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemTrade : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Item _item;
    private SlotType _originSlot;
    private SlotType _destinationSlot;

    private void Awake() => _item = GetComponent<Item>();

    public void OnDrag(PointerEventData eventData)
    {
        _originSlot = _item.ParentBeforeDrag.GetComponent<Slot>().SlotType;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        _destinationSlot = _item.ParentAfterDrag.GetComponent<Slot>().SlotType;
        if (_originSlot != _destinationSlot) 
            TradeItem();
    }

    private void TradeItem()
    {
        switch (_originSlot)
        {
            case SlotType.Shop: HandleBuy(); break;
            case SlotType.Inventory: HandleSell(); break;
            case SlotType.Equipment: HandleSell(); break;
        }
    }

    private void HandleBuy()
    {
        if (CheckPlayerCoins(_item.ItemInfo.Price))
        {
            var targetSlot = _item.ParentAfterDrag.GetComponent<Slot>();
            if (targetSlot.IsEmpty)
            {
                PlayerController.Instance.Stats.Coins -= _item.ItemInfo.Price;
                _item.transform.SetParent(_item.ParentAfterDrag);
            }
            else if (_destinationSlot == SlotType.Equipment)
            {
                PlayerController.Instance.Stats.Coins -= _item.ItemInfo.Price;
                
                var inventoryParent = PlayerController.Instance.Inventory.GetEmptySlot().transform;
                _item.transform.SetParent(inventoryParent);
                //_item.ParentAfterDrag.GetChild(0).SetParent(inventoryParent);
            }
        }
        else _item.transform.SetParent(_item.ParentBeforeDrag);
    }

    private void HandleSell()
    {
        if (_destinationSlot == SlotType.Shop)
        {
            PlayerController.Instance.Stats.Coins += _item.ItemInfo.Price;
            _item.transform.SetParent(_item.ParentAfterDrag);
        }
    }
    
    private bool CheckPlayerCoins(int itemPrice)
    {
        return PlayerController.Instance.Stats.Coins >= itemPrice;
    }
}