using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public CharacterInput Input;
    public CharacterEquipment Equipment;
    public CharacterStats Stats;
    
    public GameObject Inventory;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        Equipment = GetComponent<CharacterEquipment>();
        Stats = GetComponent<CharacterStats>();
        Input = GetComponent<CharacterInput>();
        
        Inventory.SetActive(false);
    }

    private void Start()
    {
        Input.Input_Interact += ToggleInventory;
    }

    private void ToggleInventory()
    {
        Inventory.SetActive(!Inventory.activeSelf);
    }
}
