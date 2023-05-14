using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField] private GameObject _healthVisuals;
    [SerializeField] private Image _healthImage;

    private void Start(){
        UpdateHealthBar(100f); // can be better
    }

    private void OnEnable(){
        UpdateHealthBar(100f); // can be better
    }

    private void EnableHealthVisuals(){
        _healthVisuals.SetActive(true);
    }

    private void DisableHealthVisuals(){
        _healthVisuals.SetActive(false);
    }

    public void UpdateHealthBar(float health){
        _healthImage.fillAmount = health / 100f;

        if(health < 0)
            DisableHealthVisuals();
        else if(!_healthVisuals.activeInHierarchy)
            EnableHealthVisuals();
    }
    
}
