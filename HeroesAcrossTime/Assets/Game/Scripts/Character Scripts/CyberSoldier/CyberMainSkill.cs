using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CyberMainSkill : CharacterSkillBase // high damage long range piercing shot with high cooldown
{
    [SerializeField] private Transform _beamObject;
    private Vector3 _beamStartingScale;
    
    private float _beamDamage;
    private float _beamBasedamage = 50;

    public override bool TryUseSkill(Action OnSkillUsed){
        if(!_readyToUse)
            return false;
        FireBeam();
        StartCoroutine(StartSkillCooldown());
        StartCoroutine(GlobalSkillCooldown(OnSkillUsed));
        return true;
    }

    private IEnumerator FireBeam(){
        CyberCharacter cyberCharacter = GetComponent<CyberCharacter>();
        _beamDamage += cyberCharacter.GetDamageBonusForNextShot();
        _beamObject.gameObject.SetActive(true);
        MeshRenderer beamMeshRenderer = _beamObject.GetComponent<MeshRenderer>();

        if(_beamDamage > 100)
            beamMeshRenderer.material.color = Color.red;
        else
            beamMeshRenderer.material.color = Color.blue;

        _beamObject.transform.localScale = new Vector3(_beamObject.transform.localScale.x * _beamDamage / 100f, _beamObject.transform.localScale.y * _beamDamage / 100f, _beamObject.transform.localScale.z);
        RaycastHit[] hits = Physics.RaycastAll(_playerCharacter.GetGunBarrelTransform().position, transform.forward, 50f, 128);
        foreach(RaycastHit raycastHit in hits){
            EnemyController enemyController = GetComponent<EnemyController>();
            enemyController.TakeDamage(_beamDamage);
        }

        yield return new WaitForSeconds(3f);
        
        _beamObject.gameObject.SetActive(false);
        _beamDamage = _beamBasedamage;
    }

}
