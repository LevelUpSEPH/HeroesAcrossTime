using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    [SerializeField] private List<GameObject> _levels = new List<GameObject>();
    private GameObject _currentLevel;

    private int _levelIndex = 0;

    private void Awake(){
        if(Instance != null){
            Destroy(this);

        }

        Instance = this;

        

    }

    private void Start(){
        AddListeners();
        LoadLevel();
    }

    private void OnDisable(){
        RemoveListeners();
    }   

    private void AddListeners() {
        FinishTriggerBehaviour.FinishTriggered += OnFinishTriggered;
        PlayerCharacter.PlayerDied += OnPlayerDied;
    }

    private void RemoveListeners(){
        FinishTriggerBehaviour.FinishTriggered -= OnFinishTriggered;
        PlayerCharacter.PlayerDied -= OnPlayerDied;
    }

    public void LoadLevel(){
        if(_currentLevel != null)
            _currentLevel.SetActive(false);
        _currentLevel = Instantiate(_levels[_levelIndex]);
        _levelIndex ++;
    }

    public void ReloadLevel(){
        _currentLevel.SetActive(false);
        //_levels[_levelIndex].SetActive(false);
        _currentLevel = Instantiate(_levels[_levelIndex]);
    }

    private void OnFinishTriggered(){
        LoadLevel();
    }

    private void OnPlayerDied(){
        ReloadLevel();
    }
    
}
