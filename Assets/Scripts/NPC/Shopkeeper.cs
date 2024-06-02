using DG.Tweening;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] private GameObject _shopInventory;
    
    private bool _playerOnInteractRange;
    private bool _shopOpen;
    private bool _hintHidden;
    private bool _dialogueHidden;

    private void Start()
    {
        PlayerController.Instance.Input.Input_Interact += Interact;
        _shopOpen = false;
        DOTween.Play("ResetOpenShopHint");
        DOTween.Play("ResetDialogue");
        _hintHidden = true;
        _dialogueHidden = false;
    }

    private void Interact()
    {
        if (_playerOnInteractRange)
        {
            _shopOpen = !_shopOpen;
            OpenShopInventory(_shopOpen);
            PlayerController.Instance.OpenInventory(_shopOpen);
            SwitchHint(!_shopOpen);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_hintHidden) SwitchHint(true);
        if (!_dialogueHidden) SwitchDialogue(false);
        _playerOnInteractRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!_hintHidden) SwitchHint(false);
        if (_dialogueHidden) SwitchDialogue(true);
        _playerOnInteractRange = false;
        _shopOpen = false;
        PlayerController.Instance.OpenInventory(false);
        OpenShopInventory(false);
    }
    
    private void OpenShopInventory(bool open)
    {
        if (open)
        {
            DOTween.Restart("OpenShopInventory");
            DOTween.Play("OpenShopInventory");
        }
        else DOTween.PlayBackwards("OpenShopInventory");
    }

    private void SwitchHint(bool show)
    {
        _hintHidden = !show;
        if (show)
        {
            DOTween.Restart("ShowOpenShopHint");
            DOTween.Play("ShowOpenShopHint");
        }
        else
        {
            DOTween.Restart("HideOpenShopHint");
            DOTween.Play("HideOpenShopHint");
        }
    }
    
    private void SwitchDialogue(bool show)
    {
        _dialogueHidden = !show;
        if (show)
        {
            DOTween.Restart("ShowDialogue");
            DOTween.Play("ShowDialogue");
        }
        else
        {
            DOTween.Restart("HideDialogue");
            DOTween.Play("HideDialogue");
        }
    }
}
