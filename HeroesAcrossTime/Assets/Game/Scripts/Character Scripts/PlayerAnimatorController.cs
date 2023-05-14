using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator _playerAnimator;

    private void Start(){
        ActiveCharacterController.SwitchedCharacter += OnSwitchedCharacter;
        Initialize();
    }

    private void OnDisable(){
        ActiveCharacterController.SwitchedCharacter -= OnSwitchedCharacter;
    }

    private void Initialize(){
        _playerAnimator = ActiveCharacterController.Instance.GetActivePlayerCharacter().GetComponent<Animator>();
    }

    private void OnSwitchedCharacter(PlayerCharacter playerCharacter){
        _playerAnimator = playerCharacter.GetComponent<Animator>();
    }

    public void PlayWalkingAnimation(){
        _playerAnimator.SetBool("Walking", true);
    }

    public void StopWalkingAnimation(){
        _playerAnimator.SetBool("Walking", false);
    }

}
