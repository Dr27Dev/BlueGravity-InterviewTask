using DG.Tweening;
using UnityEngine;

public class InputHint : MonoBehaviour
{
    private enum HintType { Movement, Inventory }
    [SerializeField] private HintType _hintType;

    private void Start()
    {
        switch (_hintType)
        {
            case HintType.Inventory:
                PlayerController.Instance.Input.Input_Interact += InventoryOpened;
                break;
        }
    }
    private void Update()
    {
        if (_hintType == HintType.Movement)
            if (PlayerController.Instance.Input.MovementAxis.magnitude > 0) gameObject.SetActive(false);
    }
    private void InventoryOpened()
    {
        PlayerController.Instance.Input.Input_Interact -= InventoryOpened;
        DOTween.Restart("OpenInventoryHint");
        DOTween.Play("OpenInventoryHint");
    }
}
