using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterBase : MonoBehaviour
{
    [SerializeField] protected float _health = 100f;
    [SerializeField] private CharacterSkillBase _mainSkill;
    [SerializeField] private CharacterSkillBase _secondarySkill;
    [SerializeField] private CharacterSkillBase _movementSkill;

    private bool _isActive = false;

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
    }
    
    public void Activate(){
        _isActive = true;
        // disable model 
    }

    public void Deactivate(){
        _isActive = false;
        // enable model
    }

    protected void TakeDamage(){

    }

    protected void UseSkill(CharacterSkillBase characterSkillBase){
        characterSkillBase.UseSkill();
    }

}
