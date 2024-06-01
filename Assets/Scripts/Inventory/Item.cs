using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemInfo ItemInfo;
    
    [SerializeField] private Image _image;
    private Transform _parentAfterDrag;
    private Transform _parentBeforeDrag;
    public Transform ParentAfterDrag
    {
        get => _parentAfterDrag;
        set => _parentAfterDrag = value;
    }

    private void Awake()
    {
        _image.sprite = ItemInfo.Sprite;
        _image.material = ItemInfo.Material;
    }

    public void OnBeginDrag(PointerEventData eventData) // Item picked
    {
        _parentBeforeDrag = transform.parent;
        _parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) // Item being dragged
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) // Item dropped
    {
        transform.SetParent(_parentAfterDrag);
        _image.raycastTarget = true;
        if (_parentAfterDrag == _parentBeforeDrag) OnDropFailed();
    }

    private void OnDropFailed() // This is used when item was not unequipped correctly
    {
        var equipmentSlot = GetComponentInParent<EquipmentSlot>();
        if (equipmentSlot) equipmentSlot.EquipItem(this);
    }
}
