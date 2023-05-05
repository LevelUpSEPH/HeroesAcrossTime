using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterSkillBase : MonoBehaviour
{
    protected float _skillCooldown = 1f;
    private bool _readyToUse = true;
    
    public virtual void UseSkill(Vector3 targetPosition, Action OnSkillUsed){ // cannot use two skills at once
        if(!_readyToUse)
            return;
        // use whatever skill this is
        StartCoroutine(StartSkillCooldown());
    }

    private IEnumerator StartSkillCooldown(Action OnCooldownComplete){
        yield return new WaitForSeconds(_skillCooldown);
        OnCooldownComplete();
    }
}
