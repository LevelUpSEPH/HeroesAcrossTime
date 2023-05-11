using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CowboyUltimateSkill : CharacterSkillBase // shoots a high noon bullet, if it hit; the bullet insta kills
{
    public override bool TryUseSkill(Action OnSkillUsed){
        if(!_readyToUse)
            return false;
        FireHighNoonShot();
        StartCoroutine(StartSkillCooldown());
        StartCoroutine(GlobalSkillCooldown(OnSkillUsed));
        return true;
    }

    private void FireHighNoonShot(){
        if(Physics.Raycast(_playerCharacter.GetGunBarrelTransform().position, transform.forward, out RaycastHit raycastHit, Mathf.Infinity)){
            if(raycastHit.collider.TryGetComponent<EnemyController>(out EnemyController enemyController)){
                enemyController.TakeDamage(999);
            }
        }
    }
}
