using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkillBase : MonoBehaviour
{
    protected float _skillCooldown = 1f;
    private bool _readyToUse = true;
    
    public virtual void UseSkill(){
        if(!_readyToUse)
            return;
        // use whatever skill this is
        StartCoroutine(StartSkillCooldown());
    }

    private IEnumerator StartSkillCooldown(){
        yield return new WaitForSeconds(_skillCooldown);
    }
}
