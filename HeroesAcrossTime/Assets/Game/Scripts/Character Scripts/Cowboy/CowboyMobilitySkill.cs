using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CowboyMobilitySkill : CharacterSkillBase // rolling out of danger, has iFrames
{
    public override bool TryUseSkill(Action OnSkillUsed){
        if(!_readyToUse)
            return false;
        StartBulletTime();
        StartCoroutine(StartSkillCooldown());
        StartCoroutine(GlobalSkillCooldown(OnSkillUsed));
        return true;
    }

    private IEnumerator StartBulletTime(){
        GameTimeController.Instance.EnterSlowMotion();
        yield return new WaitForSeconds(4f);
        GameTimeController.Instance.ExitSlowMotion();
    }

}
