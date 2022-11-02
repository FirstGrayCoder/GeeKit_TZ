using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameController : MonoBehaviour
{
    
    [SerializeField] private GameObject[] _players;
    [SerializeField] private GameObject _playerDice;
    [SerializeField] private GameObject _enemyDice;
    private EnemyDiceRoll _diceRoll;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _enemyStartPosition;
    public static int _rollCount;
    public static bool isFighted = false;

    [Header("UI")]
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private TextMeshProUGUI _rollCountText;
    [SerializeField] public Button _rollButton;
    [SerializeField] private Button _fightButton;
    public GameObject _panelNewRound;
  

    void Start()
    {
        _rollCount = 2;
        _fightButton.interactable = false;
        _rollButton.interactable = false;
        _panelNewRound.SetActive(false);
        _buttonPlay.GameObject().SetActive(true);
    }

    public void Update()
    {
        _rollCountText.text = "x " + _rollCount.ToString();
        if (_rollCount == 0)
        {
            _rollButton.interactable = false;
            _fightButton.interactable = true;
        }
        else if(_rollCount == 1)
        {
            _fightButton.interactable = true;
        }
        if (isFighted)
        {
            _rollButton.interactable = false;
            _fightButton.interactable = false;
        }
    }

    public void PlayGame()
    {
        _diceRoll = FindObjectOfType<EnemyDiceRoll>().GetComponent<EnemyDiceRoll>();
        _buttonPlay.GameObject().SetActive(false);
        _diceRoll.DiceRollButton();
        StartCoroutine(WaitTwoSeconds());
        if (_panelNewRound.activeSelf) _panelNewRound.SetActive(false);
    }

    public void PlayerDiceSpown()
    {
        GameObject playerTemp = Instantiate(_playerDice, _startPosition, false);
    }

    public void EnemyDiceSpown()
    {
        GameObject enemyTemp = Instantiate(_enemyDice, _enemyStartPosition, false);
    }

    public IEnumerator WaitTwoSeconds()
    {
        yield return new WaitForSeconds(2);
    }


}
