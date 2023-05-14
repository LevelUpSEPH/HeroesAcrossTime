using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CyberMobilitySkill : CharacterSkillBase
{
    public override bool TryUseSkill(Action OnSkillUsed){
        if(!_readyToUse)
            return false;
        TeleportForward();
        StartCoroutine(StartSkillCooldown());
        StartCoroutine(GlobalSkillCooldown(OnSkillUsed));
        return true;
    }

    private void TeleportForward(){
        transform.parent.position = transform.position + transform.forward * 3; // teleport 3 units fw
            
    }
}
