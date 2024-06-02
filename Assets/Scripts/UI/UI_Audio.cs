using UnityEngine;

public enum UI_Clip { ItemPickup, ItemDrop, MenuOpen, MenuClose }
public class UI_Audio : MonoBehaviour
{
    public static UI_Audio Instance;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _itemPickup_clip;
    [SerializeField] private AudioClip _itemDrop_clip;
    [SerializeField] private AudioClip _menuOpen_clip;
    [SerializeField] private AudioClip _menuClose_clip;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        _audioSource = GetComponent<AudioSource>();
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
}
