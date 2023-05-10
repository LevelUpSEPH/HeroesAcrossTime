using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActiveCharacterController : MonoBehaviour
{
    public static ActiveCharacterController Instance {get; private set;}

    public static event Action<PlayerCharacter> SwitchedCharacter;
    
    [SerializeField] private PlayerCharacter[] _availableCharacters;
    
    private PlayerCharacter _activeCharacter;

    private void Awake(){
        if(Instance != null){
            Destroy(Instance);
        }
        Instance = this;
    }

    void Start()
    {
        InitializeFirstActiveCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            if(TrySwitchToCharacter(_availableCharacters[0])){
                Debug.Log("Switching to character no : 1 ");
            }
            else{
                Debug.Log("Cannot switch");
            }
            
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            if(TrySwitchToCharacter(_availableCharacters[1])){
                Debug.Log("Switching to character no : 2 ");
            }
            else{
                Debug.Log("Cannot switch");
            }
            
        }
    }

    private void InitializeFirstActiveCharacter(){
        
        for(int i = 0; i < _availableCharacters.Length; i++){ // sets the first character in list as active character
            if(i == 0){
                _availableCharacters[i].gameObject.SetActive(true);
                _activeCharacter = _availableCharacters[i];
                _activeCharacter.Activate();
            }
            else{
                _activeCharacter.Deactivate();
                _availableCharacters[i].gameObject.SetActive(false);
            }
        }
    }

    private bool TrySwitchToCharacter(PlayerCharacter newCharacter){
        if(!newCharacter.GetIsAlive())
            return false;
        if(_activeCharacter == newCharacter){
            return false;
        }
        foreach(PlayerCharacter availableCharacter in _availableCharacters)
            availableCharacter.Deactivate();
        _activeCharacter = newCharacter;
        _activeCharacter.Activate();
        SwitchedCharacter?.Invoke(_activeCharacter);
        return true;

    }

    public PlayerCharacter GetActivePlayerCharacter(){
        return _activeCharacter;
    }
}
