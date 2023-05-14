using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthbar : MonoBehaviour
{
    [SerializeField] private PlayerCharacter _playerCharacter;
    [SerializeField] private Image _healthImage;

    private void Start(){
        UpdateHealthBar(100f); // can be better
    }

    public void UpdateHealthBar(float health){
        _healthImage.fillAmount = health / 100f;
    }
}
