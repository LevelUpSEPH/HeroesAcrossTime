using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CowboySecondarySkill : CharacterSkillBase // fires 3 shots in quick succession
{
    [SerializeField] private BulletPoolController _bulletPoolController;

    public override bool TryUseSkill(Action OnSkillUsed){
        if(!_readyToUse)
            return false;
        // use whatever skill this is
        List<GameObject> bullets = new List<GameObject>();

        for(int i = 0; i < 3; i++){
            GameObject bullet = _bulletPoolController.GetBulletToShoot();
            bullets.Add(bullet);
        }
        ShootBullets(bullets);
        Debug.Log("Waiting for " + _skillCooldown + " seconds");
        StartCoroutine(StartSkillCooldown());
        StartCoroutine(GlobalSkillCooldown(OnSkillUsed));
        return true;
    }

    private void ShootBullets(List<GameObject> bullets){
        Debug.Log("Shot 3 bullets (cowboy secondary skill)");
        // shoot the bullets
    }
    
}
