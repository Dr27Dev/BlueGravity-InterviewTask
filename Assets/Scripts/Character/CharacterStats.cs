using System;
using TMPro;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int Coins = 300;
    [SerializeField] private TextMeshProUGUI _coinsText;
    
    private void Update()
    {
        _coinsText.text = Coins.ToString("D3");
    }
}
