using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private CharacterController _characterController;
    private PlayerCharacterBase _playerCharacter;
    private GameObject _activePlayerModel;
    private float _movementSpeed = 5f;

    private void Start(){
        Initialize();
        AddListeners();
    }

    private void OnDisable(){
        RemoveListeners();
    }

    private void Update(){
        HandleMovement();
        HandleRotation();
    }

    private void Initialize(){
        _characterController = GetComponent<CharacterController>();
        _playerCharacter = ActiveCharacterController.Instance.GetActivePlayerCharacterBase();
        _activePlayerModel = _playerCharacter.gameObject;
    }
    private void AddListeners(){
        ActiveCharacterController.SwitchedCharacter += OnSwitchedCharacter;
    }

    private void RemoveListeners(){
        ActiveCharacterController.SwitchedCharacter -= OnSwitchedCharacter;
    }

    private void HandleMovement(){
        Vector3 movementDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move(movementDir * _movementSpeed * Time.deltaTime);
    }

    private void HandleRotation(){
        _activePlayerModel.transform.LookAt(MouseWorldPositionController.Instance.GetCursorPosTransform(), Vector3.up);
    }

    private void OnSwitchedCharacter(PlayerCharacterBase playerCharacterBase){
        _playerCharacter = playerCharacterBase;
        _activePlayerModel = _playerCharacter.gameObject;
    }
}
