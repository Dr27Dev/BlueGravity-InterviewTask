using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    public static CharacterEquipment Instance;
    
    [SerializeField] private GameObject _hat;
    [SerializeField] private GameObject _underwear;
    [SerializeField] private GameObject _clothes;

    private void Awake()
    {
        Instance = this;
        
        _hat.SetActive(false);
        _underwear.SetActive(false);
        _clothes.SetActive(false);
    }

    public void EquipItem(ItemType type, bool equip)
    {
        switch (type)
        {
            case ItemType.Hat: _hat.SetActive(equip); break;
            case ItemType.Underwear: _underwear.SetActive(equip); break;
            case ItemType.Clothes: _clothes.SetActive(equip); break;
        }
    }
}
