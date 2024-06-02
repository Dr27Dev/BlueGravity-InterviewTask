using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    [SerializeField] private GameObject _hat;
    [SerializeField] private GameObject _underwear;
    [SerializeField] private GameObject _clothes;

    private void Awake()
    {
        _hat.SetActive(false);
        _underwear.SetActive(false);
        _clothes.SetActive(false);
    }

    public void EquipItem(ItemType type, ItemInfo itemInfo, bool equip)
    {
        switch (type)
        {
            case ItemType.Hat: SetItem(ref _hat, itemInfo, equip); break;
            case ItemType.Underwear: SetItem(ref _underwear, itemInfo, equip); break;
            case ItemType.Clothes: SetItem(ref _clothes, itemInfo, equip); break;
        }
    }

    private void SetItem(ref GameObject item, ItemInfo itemInfo, bool equip)
    {
        item.SetActive(equip);
        if (!equip) return;

        item.GetComponent<Animator>().runtimeAnimatorController = itemInfo.AnimatorController;
        item.GetComponent<SpriteRenderer>().material = itemInfo.Material;
    }
}
