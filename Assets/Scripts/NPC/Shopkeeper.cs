using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] private GameObject _interactHint;
    [SerializeField] private GameObject _shopInventory;

    private bool _playerOnInteractRange;
    private bool _shopOpen;

    private void Start()
    {
        PlayerController.Instance.Input.Input_Interact += Interact;
        _interactHint.SetActive(false);
        _shopInventory.SetActive(false);
        _shopOpen = false;
    }

    private void Interact()
    {
        if (_playerOnInteractRange)
        {
            _shopOpen = !_shopOpen;
            _shopInventory.SetActive(_shopOpen);
            PlayerController.Instance.Inventory.SetActive(_shopOpen);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _interactHint.SetActive(true);
        _playerOnInteractRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _interactHint.SetActive(false);
        _playerOnInteractRange = false;
        _shopInventory.SetActive(false);
        _shopOpen = false;
        PlayerController.Instance.Inventory.SetActive(false);
    }
}
