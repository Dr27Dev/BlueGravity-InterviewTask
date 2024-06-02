using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemInfo ItemInfo;
    private Image _image;
    
    [HideInInspector] public Transform ParentAfterDrag;
    [HideInInspector] public Transform ParentBeforeDrag;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.sprite = ItemInfo.Sprite;
        _image.material = ItemInfo.Material;
    }

    public void OnBeginDrag(PointerEventData eventData) // Item picked
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        ItemInfoBox.Instance.IsDraggingItem = true;
        ParentBeforeDrag = transform.parent;
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) // Item being dragged
    {
        if (eventData.button == PointerEventData.InputButton.Left) 
            transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) // Item dropped
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        ItemInfoBox.Instance.IsDraggingItem = false;
        transform.SetParent(ParentAfterDrag);
        _image.raycastTarget = true;
        if (ParentAfterDrag == ParentBeforeDrag) OnDropFailed();
    }

    private void OnDropFailed() // This is used when item was not unequipped correctly
    {
        var equipmentSlot = GetComponentInParent<EquipmentSlot>();
        if (equipmentSlot) equipmentSlot.EquipItem(this);
    }
}