using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] protected float _health = 100f;
    [SerializeField] private CharacterSkillBase _mainSkill; // shooting
    [SerializeField] private CharacterSkillBase _secondarySkill; // special ability (burst / aoe)
    [SerializeField] private CharacterSkillBase _movementSkill; // dash / teleport / roll
    [SerializeField] private CharacterSkillBase _ultimateSkill;

    private bool _isActive = false;
    protected float _ultMaxPoint;
    protected float _ultPoint;
    protected bool _canUseSkill = true;
    protected bool _isAlive = true;

    private void Update(){
        if(!_isAlive)
            return;
        if(!_isActive)
            return;
        if(_canUseSkill){
            HandleSkills();
        }
            
            
    }

    private void HandleSkills(){

        if(Input.GetMouseButtonDown(0)){
            TryUseSkill(_mainSkill);
        }

        if(Input.GetMouseButton(1)){
            TryUseSkill(_secondarySkill);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
            TryUseSkill(_movementSkill);
        
        if(Input.GetKeyDown(KeyCode.Q)){
            if(_ultPoint >= _ultMaxPoint)
                TryUseSkill(_ultimateSkill);
        }
    }
    
    public void Activate(){
        _isActive = true;
        // enable model 
    }

    public void Deactivate(){
        _isActive = false;
        // disable model
    }

    protected void TakeDamage(float damage){
        _health -= damage;

        if(_health <= 0)
            Die();
    }

    protected void Die(){
        _isAlive = false;
    }

    protected void TryUseSkill(CharacterSkillBase characterSkillBase){
        if(characterSkillBase.TryUseSkill(Vector3.zero, ResetCanUseSkill)){
            _canUseSkill = false;    
            return;
        }
        
    }

    protected void ResetCanUseSkill(){
        _canUseSkill = true;
    }
    
    public bool GetIsAlive(){
        return _isAlive;
    }
}
