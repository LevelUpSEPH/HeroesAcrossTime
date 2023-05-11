using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CyberSecondarySkill : CharacterSkillBase // charges the damage of first ability, stands still while doing so
{

    private float _nextShotDamageBonus = 0;

    public override bool TryUseSkill(Action OnSkillUsed){
        if(!_readyToUse)
            return false;
        ChargeMainShot();
        StartCoroutine(StartSkillCooldown());
        StartCoroutine(GlobalSkillCooldown(OnSkillUsed));
        return true;
    }

    private void ChargeMainShot(){
        CyberCharacter cyberCharacter = GetComponent<CyberCharacter>(); // bad coding
        if(cyberCharacter.GetHealth() > 15f){
            _nextShotDamageBonus += 15f;
            cyberCharacter.TakeDamage(15f);
            cyberCharacter.IncreaseDamageBonusForNextShot(_nextShotDamageBonus);
        }
            
    }

}
