using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CowboyMainSkill : CharacterSkillBase // basic revolver shooting
{
    [SerializeField] private BulletPoolController _bulletPoolController;
    private float bulletDamage = 40f;

    public override bool TryUseSkill(Action OnSkillUsed){
        if(!_readyToUse)
            return false;
        Shoot();
        StartCoroutine(StartSkillCooldown());
        StartCoroutine(GlobalSkillCooldown(OnSkillUsed));
        return true;
    }

    private void Shoot(){
        Debug.Log("Shot bullet (cowboymainskill)");
        GameObject bullet = _bulletPoolController.GetBulletToShoot();
        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
        bullet.SetActive(true);
        bullet.transform.position = _playerCharacter.GetGunBarrelTransform().position;
        bulletBehaviour.InitializeBullet(50, bulletDamage, transform.rotation);
    }

}
