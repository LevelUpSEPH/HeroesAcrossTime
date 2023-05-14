using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _enemyAnimator;
    
    public void PlayMovingAnimation(){
        _enemyAnimator.SetBool("Walking", true);
    }

    public void StopMovingAnimation(){
        _enemyAnimator.SetBool("Walking", false);
    }

}
