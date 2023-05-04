using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharacterController : MonoBehaviour
{
    
    [SerializeField] private PlayerCharacterBase[] _availableCharacters;
    
    private PlayerCharacterBase _activeCharacter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            SwitchToCharacter(_availableCharacters[0]);
            Debug.Log("Switching to character no : 1 ");
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            SwitchToCharacter(_availableCharacters[1]);
            Debug.Log("Switching to character no : 2 ");
        }
    }

    private void SwitchToCharacter(PlayerCharacterBase playerCharacterBase){
        if(_activeCharacter == playerCharacterBase){
            return;
        }
        foreach(PlayerCharacterBase playerCharacterbase in _availableCharacters)
            playerCharacterbase.Deactivate();
        _activeCharacter = playerCharacterBase;
        _activeCharacter.Activate();

    }
}
