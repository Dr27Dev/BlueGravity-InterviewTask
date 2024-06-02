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
        if (_originSlot == SlotType.Shop) PlayerController.Instance.Equipment.SetTradingBlock(true);
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        _destinationSlot = _item.ParentAfterDrag.GetComponent<Slot>().SlotType;
        if (_originSlot != _destinationSlot) 
            TradeItem();
        if (_originSlot == SlotType.Shop) PlayerController.Instance.Equipment.SetTradingBlock(false);
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
        if (CheckPlayerCoins(_item.ItemInfo.Price) && _destinationSlot != SlotType.Equipment)
        {
            var targetSlot = _item.ParentAfterDrag.GetComponent<Slot>();
            if (targetSlot.IsEmpty)
            {
                PlayerController.Instance.Stats.Coins -= _item.ItemInfo.Price;
                _item.transform.SetParent(_item.ParentAfterDrag);
            }
            else
            {
                targetSlot.PreviouslyHeldItem.transform.SetParent(_item.ParentAfterDrag);
                _item.transform.SetParent(_item.ParentBeforeDrag);
            }
        }
        else _item.transform.SetParent(_item.ParentBeforeDrag);
    }

    private void HandleSell()
    {
        if (_destinationSlot != SlotType.Shop) return;
        var targetSlot = _item.ParentAfterDrag.GetComponent<Slot>();
        if (targetSlot.IsEmpty)
        {
            PlayerController.Instance.Stats.Coins += _item.ItemInfo.Price;
            _item.transform.SetParent(_item.ParentAfterDrag);
        }
        else
        {
            targetSlot.PreviouslyHeldItem.transform.SetParent(_item.ParentAfterDrag);
            _item.transform.SetParent(_item.ParentBeforeDrag);
        }
    }
    
    private bool CheckPlayerCoins(int itemPrice)
    {
        return PlayerController.Instance.Stats.Coins >= itemPrice;
    }
}