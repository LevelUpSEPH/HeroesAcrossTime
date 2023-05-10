using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CowboySecondarySkill : CharacterSkillBase // fires 3 shots in quick succession
{
    [SerializeField] private BulletPoolController _bulletPoolController;
    new protected float _skillCooldown = 3f;

    public override void UseSkill(Vector3 targetPosition, Action OnSkillUsed){
        if(!_readyToUse)
            return;
        // use whatever skill this is
        List<GameObject> bullets = new List<GameObject>();

        for(int i = 0; i < 3; i++){
            GameObject bullet = _bulletPoolController.GetBulletToShoot();
            bullets.Add(bullet);
        }
        ShootBullets(bullets);
        
        StartCoroutine(StartSkillCooldown());
        StartCoroutine(GlobalSkillCooldown(OnSkillUsed));
    }

    private void ShootBullets(List<GameObject> bullets){
        Debug.Log("Shot 3 bullets (cowboy secondary skill)");
        // shoot the bullets
    }
}
