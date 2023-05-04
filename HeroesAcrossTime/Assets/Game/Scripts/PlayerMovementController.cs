using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private CharacterController _characterController;
    private float _movementSpeed = 5f;

    private void Start(){
        _characterController = GetComponent<CharacterController>();
    }

    private void Update(){
        HandleMovement();
    }

    private void HandleMovement(){
        Vector3 movementDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move(movementDir * _movementSpeed * Time.deltaTime);
    }

}
