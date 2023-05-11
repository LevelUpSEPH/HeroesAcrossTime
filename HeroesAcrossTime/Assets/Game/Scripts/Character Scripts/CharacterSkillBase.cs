using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterSkillBase : MonoBehaviour
{
    [SerializeField] protected float _skillCooldown = 1f;
    protected bool _readyToUse = true;
    protected PlayerCharacter _playerCharacter;

    private void Awake(){
        _playerCharacter = GetComponent<PlayerCharacter>();
    }
    
    public virtual bool TryUseSkill(Action OnSkillUsed){ 
        if(!_readyToUse)
            return false;
        // use whatever skill this is
        StartCoroutine(StartSkillCooldown());
        StartCoroutine(GlobalSkillCooldown(OnSkillUsed)); // cooldown before using another skill
        return true;
    }

    protected IEnumerator StartSkillCooldown(){
        _readyToUse = false;
        yield return new WaitForSeconds(_skillCooldown);
        _readyToUse = true;
    }

    protected IEnumerator GlobalSkillCooldown(Action OnCooldownComplete){
        yield return new WaitForSeconds(0.5f);
        OnCooldownComplete();
    }
}
