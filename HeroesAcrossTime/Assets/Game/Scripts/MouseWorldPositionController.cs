using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorldPositionController : MonoBehaviour
{
    public static MouseWorldPositionController Instance {get; private set;}

    [SerializeField] private Transform _mouseWorldPosRefTransform; // will be used to help characters follow player's cursor
    private Vector3 _mouseWorldPosition;

    private void Awake(){
        if(Instance != null){
            Destroy(Instance);
        }
        Instance = this;
    }

    void Update()
    {
        CalculateMouseWorldPosition();
        MoveReference();
    }

    private void CalculateMouseWorldPosition(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, 20f, 64)){ // touched the ground
            _mouseWorldPosition = raycastHit.point;
        }
    }

    private void MoveReference(){
        //Vector3 refPos = new Vector3(_mouseWorldPosition.x, _mouseWorldPosition.y + 2, _mouseWorldPosition.z);
        _mouseWorldPosRefTransform.position = _mouseWorldPosition;
    }

    public Transform GetCursorPosTransform(){
        return _mouseWorldPosRefTransform;
    }

}
