using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterBase : MonoBehaviour
{
    [SerializeField] protected float _health = 100f;
    [SerializeField] private CharacterSkillBase _mainSkill; // shooting
    [SerializeField] private CharacterSkillBase _secondarySkill; // special ability (burst / aoe)
    [SerializeField] private CharacterSkillBase _movementSkill; // dash / teleport / roll
    [SerializeField] private CharacterSkillBase _ultimateSkill;

    private bool _isActive = false;
    protected float _ultMaxPoint;
    protected float _ultPoint;

    private void Update(){
        if(!_isActive)
            return;
        if(Input.GetMouseButtonDown(0)){
            UseSkill(_mainSkill);
        }

        if(Input.GetMouseButton(1)){
            UseSkill(_secondarySkill);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
            UseSkill(_movementSkill);
        
        if(Input.GetKeyDown(KeyCode.Q)){
            if(_ultPoint >= _ultMaxPoint)
                UseSkill(_ultimateSkill);
        }
            
    }
    
    public void Activate(){
        _isActive = true;
        // disable model 
    }

    public void Deactivate(){
        _isActive = false;
        // enable model
    }

    protected void TakeDamage(float damage){
        _health -= damage;

        if(_health <= 0)
            Die();
    }

    protected void Die(){
        // die
    }

    protected void UseSkill(CharacterSkillBase characterSkillBase){
        characterSkillBase.UseSkill();
    }

}
