using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActiveCharacterController : MonoBehaviour
{
    public static ActiveCharacterController Instance {get; private set;}

    public static event Action<PlayerCharacterBase> SwitchedCharacter;
    
    [SerializeField] private PlayerCharacterBase[] _availableCharacters;
    
    private PlayerCharacterBase _activeCharacter;

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
            SwitchToCharacter(_availableCharacters[0]);
            Debug.Log("Switching to character no : 1 ");
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            SwitchToCharacter(_availableCharacters[1]);
            Debug.Log("Switching to character no : 2 ");
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

    private void SwitchToCharacter(PlayerCharacterBase playerCharacterBase){
        if(_activeCharacter == playerCharacterBase){
            return;
        }
        foreach(PlayerCharacterBase playerCharacterbase in _availableCharacters)
            playerCharacterbase.Deactivate();
        _activeCharacter = playerCharacterBase;
        _activeCharacter.Activate();
        SwitchedCharacter?.Invoke(_activeCharacter);

    }

    public PlayerCharacterBase GetActivePlayerCharacterBase(){
        return _activeCharacter;
    }
}
