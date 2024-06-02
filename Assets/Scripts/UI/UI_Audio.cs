using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public enum UI_Clip { ItemPickup, ItemDrop, MenuOpen, MenuClose }
public class UI_Audio : MonoBehaviour
{
    public static UI_Audio Instance;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _itemPickup_clip;
    [SerializeField] private AudioClip _itemDrop_clip;
    [SerializeField] private AudioClip _menuOpen_clip;
    [SerializeField] private AudioClip _menuClose_clip;

    [SerializeField] private Sprite _mutedSprite;
    [SerializeField] private Sprite _unmuttedSprite;
    [SerializeField] private Image _muteButtonImage;

    [SerializeField] private AudioMixer _mixer;
    
    private bool _muted;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        _audioSource = GetComponent<AudioSource>();
        _muted = false;
    }

    public void PlaySoundOnce(UI_Clip clip, float volumeLevel)
    {
        switch (clip)
        {
            case UI_Clip.ItemPickup: _audioSource.PlayOneShot(_itemPickup_clip, volumeLevel); break;
            case UI_Clip.ItemDrop: _audioSource.PlayOneShot(_itemDrop_clip, volumeLevel); break;
            case UI_Clip.MenuOpen: _audioSource.PlayOneShot(_menuOpen_clip, volumeLevel); break;
            case UI_Clip.MenuClose: _audioSource.PlayOneShot(_menuClose_clip, volumeLevel); break;
        }
    }

    public void ToggleMute()
    {
        _muted = !_muted;
        if (_muted)
        {
            _muteButtonImage.sprite = _mutedSprite;
            _mixer.SetFloat("Volume", -80f);
        }
        else
        {
            _muteButtonImage.sprite = _unmuttedSprite;
            _mixer.SetFloat("Volume", 0);
        }
    }
}