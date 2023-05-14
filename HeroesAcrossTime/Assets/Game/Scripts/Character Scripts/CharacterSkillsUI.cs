using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkillsUI : MonoBehaviour
{
    [SerializeField] private GameObject _imgPrefab;
    private List<CharacterSkillBase> _activeSkills = new List<CharacterSkillBase>();
    private List<GameObject> _skillImages = new List<GameObject>();

    private void Start(){
        Initialize();
        ActiveCharacterController.SwitchedCharacter += OnSwitchedCharacter;
    }

    private void OnDisable(){
        ActiveCharacterController.SwitchedCharacter -= OnSwitchedCharacter;
    }

    private void Initialize(){
        _activeSkills.AddRange(ActiveCharacterController.Instance.GetActivePlayerCharacter().GetComponents<CharacterSkillBase>());
    }

    private void Update(){
        UpdateUI(); // can be called when a skill is used instead for performance
    }

    private void OnSwitchedCharacter(PlayerCharacter playerCharacter){
        ResetUI();
        _activeSkills.Clear();
        _activeSkills.AddRange(playerCharacter.GetComponents<CharacterSkillBase>());
        CreateNewUI();
    }

    private void CreateNewUI(){
        foreach(CharacterSkillBase characterSkill in _activeSkills){
            GameObject image = Instantiate(_imgPrefab, transform);
            _skillImages.Add(image);
        }
    }

    private void UpdateUI(){
        for(int i = 0; i < _skillImages.Count; i++){
            if(_activeSkills[i].GetSkillIsReady())
                _skillImages[i].GetComponent<Image>().color = Color.white;
            else
                _skillImages[i].GetComponent<Image>().color = Color.black;
        }
    }

    private void ResetUI(){
        foreach(GameObject image in _skillImages)
            Destroy(image);
        _skillImages.Clear();
    }
}
