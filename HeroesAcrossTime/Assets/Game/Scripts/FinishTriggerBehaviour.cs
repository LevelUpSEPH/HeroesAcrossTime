using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinishTriggerBehaviour : MonoBehaviour
{
    public static event Action FinishTriggered;
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            FinishTriggered?.Invoke();
        }

    }
}
