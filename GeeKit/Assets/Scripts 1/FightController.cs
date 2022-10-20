using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    private GameObject _playerSkillsParent;
    private GameObject _enemySkillsParent;
    private EnemyObject _enemyObject;
    private PlayerObject _playerObject;
    private EnemyDiceRoll _diceRoll;
    private PlayerDicerRoll _playerDiceRoll;
    void Start()
    {
        _playerSkillsParent = GameObject.Find("PlayerSkills");
        _enemySkillsParent = GameObject.Find("EnemySkills");
        _enemyObject = FindObjectOfType<EnemyObject>();
        _playerObject = FindObjectOfType<PlayerObject>();
        _diceRoll = FindObjectOfType<EnemyDiceRoll>().GetComponent<EnemyDiceRoll>();
        _playerDiceRoll = FindObjectOfType<PlayerDicerRoll>().GetComponent<PlayerDicerRoll>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FightButton()
    {
        for (int i = 0; i < _playerSkillsParent.transform.childCount; i++)
        {
                if (_playerSkillsParent.transform.GetChild(i).gameObject.activeInHierarchy && _playerSkillsParent.transform.GetChild(i).name == "Mana") return;
                else if (_playerSkillsParent.transform.GetChild(i).gameObject.activeInHierarchy && _playerSkillsParent.transform.GetChild(i).name == "HeartEnergy")
                { 
                    _playerObject.GetHealth();
                    _playerObject.DemageFromEnemy();
                }
                
                else if (_playerSkillsParent.transform.GetChild(i).gameObject.activeInHierarchy && _playerSkillsParent.transform.GetChild(i).name == "Armor") _playerObject.DemageFromEnemy();
                else if (_playerSkillsParent.transform.GetChild(i).gameObject.activeInHierarchy && _playerSkillsParent.transform.GetChild(i).name == "Hammer") _enemyObject.DemageFromPlayer();
        }
        _diceRoll.DiceRollButton();
        //_playerDiceRoll.DiceRollButton();

    }
}
