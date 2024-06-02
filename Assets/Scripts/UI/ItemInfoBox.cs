using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInfoBox : MonoBehaviour
{
    public static ItemInfoBox Instance;
    [SerializeField] private GameObject _box;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _cost;

    private Item _currentItem;
    public bool IsDraggingItem;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
        IsDraggingItem = false;
    }

    private void Update() => DetectButtonUnderMouse();

    private void DetectButtonUnderMouse()
    {
        _currentItem = null;
        _box.SetActive(false);
        if (!IsDraggingItem)
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);
        
            foreach (RaycastResult result in raycastResults)
            {
                Item item = result.gameObject.GetComponent<Item>();
                if (item != null) _currentItem = item;
            }

            if (_currentItem != null)
            {
                _box.transform.position = Input.mousePosition;
                _box.SetActive(true);
                _name.text = _currentItem.ItemInfo.Name;
                _cost.text = _currentItem.ItemInfo.Price.ToString("D3");
            }
        }
    }
}
