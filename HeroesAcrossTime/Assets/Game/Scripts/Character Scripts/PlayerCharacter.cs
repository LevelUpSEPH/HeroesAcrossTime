using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] protected float _health = 100f;
    [SerializeField] protected GameObject _playerModel;
    [SerializeField] protected Transform _gunBarrelPosition;
    [SerializeField] protected CharacterSkillBase _mainSkill; // shooting
    [SerializeField] protected CharacterSkillBase _secondarySkill; // special ability (burst / aoe)
    [SerializeField] protected CharacterSkillBase _movementSkill; // dash / teleport / roll
    [SerializeField] protected CharacterSkillBase _ultimateSkill;

    private PlayerMovementController _playerMovementController;
    private bool _isActive = false;
    protected bool _canUseSkill = true;
    protected bool _isAlive = true;

    protected virtual void Update(){
        if(!_isAlive)
            return;
        if(!_isActive)
            return;
        if(_canUseSkill){
            HandleSkills();
        }
            
            
    }

    protected virtual void HandleSkills(){

        if(Input.GetMouseButtonDown(0)){
            TryUseSkill(_mainSkill);
        }

        if(Input.GetMouseButtonDown(1)){
            TryUseSkill(_secondarySkill);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
            TryUseSkill(_movementSkill);
        
        if(Input.GetKeyDown(KeyCode.Q)){
                TryUseSkill(_ultimateSkill);
        }
    }
    
    public void Activate(){
        _isActive = true;
    }

    public void Deactivate(){
        _isActive = false;
    }

    public virtual void TakeDamage(float damage){
        _health -= damage;

        if(_health <= 0)
            Die();
    }

    protected void Die(){
        _isAlive = false;
    }

    protected void TryUseSkill(CharacterSkillBase characterSkillBase){
        if(characterSkillBase.TryUseSkill(ResetCanUseSkill)){
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

    public GameObject GetPlayerModel(){
        return _playerModel;
    }

    public Transform GetGunBarrelTransform(){
        return _gunBarrelPosition;
    }

    public float GetHealth(){
        return _health;
    }

    public void SetPlayerMovementController(PlayerMovementController playerMovementController){
        _playerMovementController = playerMovementController;
    }

}
