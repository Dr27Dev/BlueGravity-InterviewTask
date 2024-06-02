using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public CharacterEquipment Equipment;
    public CharacterStats Stats;
    public Inventory Inventory;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        Equipment = GetComponent<CharacterEquipment>();
        Stats = GetComponent<CharacterStats>();
    }
}
