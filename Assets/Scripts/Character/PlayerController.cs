using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public CharacterInput Input;
    public CharacterEquipment Equipment;
    public CharacterStats Stats;
    
    private bool _inventoryOpen;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        Equipment = GetComponent<CharacterEquipment>();
        Stats = GetComponent<CharacterStats>();
        Input = GetComponent<CharacterInput>();
    }

    private void Start() => Input.Input_Interact += ToggleInventory;
    private void ToggleInventory() => OpenInventory(!_inventoryOpen);

    public void OpenInventory(bool open)
    {
        _inventoryOpen = open;
        if (open)
        {
            DOTween.Restart("OpenInventory");
            DOTween.Play("OpenInventory");
        }
        else DOTween.PlayBackwards("OpenInventory");
    }
}
