using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightController : MonoBehaviour
{
    [SerializeField] private GameObject _playerSkillsParent;
    [SerializeField] private GameObject _enemySkillsParent;
    private EnemyObject _enemyObject;
    private PlayerObject _playerObject;
    private EnemyDiceRoll _diceRoll;
    private GameObject _playerDiceRoll;
    private GameObject _enemyDiceRoll;
    public GameController _gameController;
    public GameObject _panelNewRound;

    [SerializeField] private DiceSpown _playerDiceSpown;
    [SerializeField] private DiceSpown _enemyDiceSpown;
    private int demage;
    private int playerHP;

    [Header("Animations")]
    [SerializeField] private Animator _playerAnim;
    [SerializeField] private Animator _enemyAnim;


    void Start()
    {
        _panelNewRound.SetActive(false);
        _playerSkillsParent = GameObject.Find("PlayerSkills");
        _enemySkillsParent = GameObject.Find("EnemySkills");
        _enemyObject = FindObjectOfType<EnemyObject>();
        _playerObject = FindObjectOfType<PlayerObject>();
        _playerDiceSpown.GetComponent<DiceSpown>();
        _enemyDiceSpown.GetComponent<DiceSpown>();
        _gameController = GetComponent<GameController>();   
    }

    public void PlayEnemyAnim()
    {
        _enemyAnim.SetTrigger("Play");
    }

    public void PlayPlayerAnim()
    {
        _playerAnim.SetTrigger("Play");
    }

    public void AtackButton()
    {
        GameController.isFighted = true;
        GameController._rollCount = 2;
        _panelNewRound.SetActive(true);
        StartCoroutine(WaitOneSecond());
    }

    public void NewRound()
    {
        CloseAllPlayerSkills();
        CloseAllEnemySkills();
        _panelNewRound.SetActive(false);
        PlayNewRound();
    }

    public void PlayNewRound()
    {
        GameController.isFighted = false;
        _playerDiceSpown.PlayerSpown();
        _enemyDiceSpown.PlayerSpown();
        _diceRoll = FindObjectOfType<EnemyDiceRoll>().GetComponent<EnemyDiceRoll>();
        _diceRoll.DiceRollButton();   
    }

    IEnumerator WaitOneSecond()
    {
        PlayerWeapon();
        PlayEnemyAnim();
        yield return new WaitForSeconds(1);
        EnemyWeapon();
        PlayPlayerAnim();
    }
    public void CloseAllPlayerSkills()
    {
        for (int i = 0; i < _playerSkillsParent.transform.childCount; i++)
        {
            _playerSkillsParent.transform.GetChild(i).gameObject.SetActive(false);
        }
        GameController._rollCount = 2;
    }
    public void CloseAllEnemySkills()
    {
        for (int i = 0; i < _enemySkillsParent.transform.childCount; i++)
        {
            _enemySkillsParent.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void PlayerWeapon()
    {
        for (int i =0; i < _playerSkillsParent.transform.childCount; i++)
        {
            if (_playerSkillsParent.transform.GetChild(i).gameObject.activeSelf)
            {
                switch (_playerSkillsParent.transform.GetChild(i).gameObject.name)
                {
                    case "skill1":
                        demage = 30;
                        _enemyObject.DemageFromPlayer(demage);
                        break;
                    case "skill2":
                        demage = 10;
                        _enemyObject.DemageFromPlayer(demage);
                        break;
                    case "skill3":
                        playerHP = 20;
                        _playerObject.GetHealth(playerHP);
                        break;
                    case "skill4":
                        demage = 30;
                        _enemyObject.DemageFromPlayer(demage);
                        break;
                    case "skill5":
                        demage = 10;
                        _enemyObject.DemageFromPlayer(demage);
                        break;
                    case "skill6":
                        demage = 30;
                        _enemyObject.DemageFromPlayer(demage);
                        break;
                }
            }
        }
    }

    public void EnemyWeapon()
    {
        for (int i = 0; i < _enemySkillsParent.transform.childCount; i++)
        {
            if (_enemySkillsParent.transform.GetChild(i).gameObject.activeSelf)
            {
                switch (_enemySkillsParent.transform.GetChild(i).gameObject.name)
                {
                    case "skill1":
                        PlayerObject._demageFromEnemy = 10;

                        break;
                    case "skill2":
                        PlayerObject._demageFromEnemy = 20;

                        break;
                    case "skill3":
                        PlayerObject._demageFromEnemy = 30;

                        break;
                    case "skill4":
                        PlayerObject._demageFromEnemy = 20;

                        break;
                    case "skill5":
                        PlayerObject._demageFromEnemy = 10;

                        break;
                    case "skill6":
                        PlayerObject._demageFromEnemy = 10;

                        break;
                }
                _playerObject.AtackOnArmor();
            }
        }
    }
}
