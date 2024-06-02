using DG.Tweening;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    private bool _playerOnInteractRange;
    private bool _shopOpen;
    private bool _hintHidden;

    private void Start()
    {
        PlayerController.Instance.Input.Input_Interact += Interact;
        _shopOpen = false;
        DOTween.Play("ResetOpenShopHint");
        DOTween.Play("ResetDialogue");
        _hintHidden = true;
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
        SwitchDialogue(false);
        _playerOnInteractRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!_hintHidden) SwitchHint(false);
        if (_hintHidden) SwitchDialogue(true);
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
            DOTween.Complete("HideOpenShopHint");
            DOTween.Restart("ShowOpenShopHint");
            DOTween.Play("ShowOpenShopHint");
        }
        else
        {
            DOTween.Complete("ShowOpenShopHint");
            DOTween.Restart("HideOpenShopHint");
            DOTween.Play("HideOpenShopHint");
        }
    }
    
    private void SwitchDialogue(bool show)
    {
        if (show)
        {
            DOTween.Complete("HideDialogue");
            DOTween.Restart("ShowDialogue");
            DOTween.Play("ShowDialogue");
        }
        else
        {
            DOTween.Complete("ShowDialogue");
            DOTween.Restart("HideDialogue");
            DOTween.Play("HideDialogue");
        }
    }
}
