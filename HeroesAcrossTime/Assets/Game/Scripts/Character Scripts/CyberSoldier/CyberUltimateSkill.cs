using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CyberUltimateSkill : CharacterSkillBase // triple the damagebonus
{
    public override bool TryUseSkill(Action OnSkillUsed){
        if(!_readyToUse)
            return false;
            
        TripleDamageBonus();
        StartCoroutine(StartSkillCooldown());
        StartCoroutine(GlobalSkillCooldown(OnSkillUsed));
        return true;
    }

    private void TripleDamageBonus(){
        CyberCharacter cyberCharacter = GetComponent<CyberCharacter>();
        cyberCharacter.IncreaseDamageBonusForNextShot(cyberCharacter.GetDamageBonusForNextShot() * 2);
    }
}
