using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CowboyMainSkill : CharacterSkillBase // basic revolver shooting
{
    [SerializeField] private BulletPoolController _bulletPoolController;
    new protected float _skillCooldown = 0.7f;

    public override void UseSkill(Vector3 targetPosition, Action OnSkillUsed){
        if(!_readyToUse)
            return;
        Shoot();
        StartCoroutine(StartSkillCooldown());
        StartCoroutine(GlobalSkillCooldown(OnSkillUsed));
    }

    private void Shoot(){
        Debug.Log("Shot bullet (cowboymainskill)");
        //GameObject bullet = _bulletPoolController.GetBulletToShoot();
        // bullet moves with dotween towards the look direction / moves normally depending on delta time and model transform forward, will see
        // bullet damages the target it hits, not the character itself
    }

}
