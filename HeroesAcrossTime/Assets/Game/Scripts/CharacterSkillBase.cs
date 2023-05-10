using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterSkillBase : MonoBehaviour
{
    protected float _skillCooldown = 1f;
    protected bool _readyToUse = true;
    
    public virtual void UseSkill(Vector3 targetPosition, Action OnSkillUsed){ 
        if(!_readyToUse)
            return;
        // use whatever skill this is
        StartCoroutine(StartSkillCooldown());
        StartCoroutine(GlobalSkillCooldown(OnSkillUsed)); // cooldown before using another skill
    }

    protected IEnumerator StartSkillCooldown(){
        yield return new WaitForSeconds(_skillCooldown);
    }

    protected IEnumerator GlobalSkillCooldown(Action OnCooldownComplete){
        yield return new WaitForSeconds(0.5f);
        OnCooldownComplete();
    }
}
