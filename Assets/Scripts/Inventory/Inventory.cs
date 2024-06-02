using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Slot[] _inventorySlots;

    private void Start()
    {
        PlayerController.Instance.Inventory = this;
    }

    public Slot GetEmptySlot()
    {
        foreach (var slot in _inventorySlots) 
            if (slot.IsEmpty) return slot;
        return null;
    }
}
