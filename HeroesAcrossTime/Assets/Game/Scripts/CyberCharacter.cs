using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberCharacter : PlayerCharacter
{
    private bool _tookDamageLately = false;
    private float _healthRegenMultiplier;
    private float _nextShotDamageBonus = 0;
    
    protected override void Update()
    {
        base.Update();

        if(!_tookDamageLately)
            _health += Time.deltaTime * _healthRegenMultiplier;
    }

    protected override void HandleSkills(){

        if(Input.GetMouseButtonDown(0)){
            TryUseSkill(_mainSkill);
        }

        if(Input.GetMouseButtonDown(1)){
            TryUseSkill(_secondarySkill);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
            TryUseSkill(_movementSkill);
        
        if(Input.GetKeyDown(KeyCode.Q)){
            TryUseSkill(_ultimateSkill);
        }
    }

    public override void TakeDamage(float damage){
        _health -= damage;
        _tookDamageLately = true;

        StartCoroutine(StartTookDamageCountdown());

        if(_health <= 0)
            Die();
    }

    private IEnumerator StartTookDamageCountdown(){
        yield return new WaitForSeconds(3f);
        _tookDamageLately = false;
    }

    public void IncreaseDamageBonusForNextShot(float damageBonus){
        _nextShotDamageBonus += damageBonus;
    }

    public float GetDamageBonusForNextShot(){
        return _nextShotDamageBonus;
    }
}
