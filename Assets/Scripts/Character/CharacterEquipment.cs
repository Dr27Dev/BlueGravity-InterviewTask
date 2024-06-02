using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    [SerializeField] private GameObject _hat;
    [SerializeField] private GameObject _underwear;
    [SerializeField] private GameObject _clothes;
    [SerializeField] private GameObject _tradingBlock;

    private bool _isTrading;

    private void Awake()
    {
        _hat.SetActive(false);
        _underwear.SetActive(false);
        _clothes.SetActive(false);
        SetTradingBlock(false);
    }
    public void EquipItem(ItemType type, ItemInfo itemInfo, bool equip)
    {
        if (_isTrading) return;
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
    public void SetTradingBlock(bool isTrading)
    {
        _isTrading = isTrading;
        _tradingBlock.SetActive(isTrading);
    }
}
