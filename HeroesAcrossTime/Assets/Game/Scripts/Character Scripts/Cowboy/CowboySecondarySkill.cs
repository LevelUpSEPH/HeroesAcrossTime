using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CowboySecondarySkill : CharacterSkillBase // fires 3 shots in quick succession
{
    [SerializeField] private BulletPoolController _bulletPoolController;
    private float bulletDamage = 35f;

    public override bool TryUseSkill(Action OnSkillUsed){
        if(!_readyToUse)
            return false;
        
        ShootBullets();
        Debug.Log("Waiting for " + _skillCooldown + " seconds");
        StartCoroutine(StartSkillCooldown());
        StartCoroutine(GlobalSkillCooldown(OnSkillUsed));
        return true;
    }

    private void ShootBullets(){
        List<GameObject> bullets = new List<GameObject>();
        Debug.Log("Shot some bullets (cowboy secondary skill)");

        for(int i = 0; i < 3; i++){
            GameObject bullet = _bulletPoolController.GetBulletToShoot(); // adds the first bullet three times?
            bullet.SetActive(true);
            bullets.Add(bullet);
        }

        foreach(GameObject bullet in bullets){
            BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
            bullet.transform.position = _playerCharacter.GetGunBarrelTransform().position;
            bulletBehaviour.InitializeBullet(50, bulletDamage, true, transform.rotation);
            // shot the bullet
            bullets.Remove(bullet);
        }
    }
    
}
