using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private GameObject[] _players;
    [SerializeField] private GameObject _playerDice;
    private EnemyDiceRoll _diceRoll;
    private EnemyDiceController EnemyDiceController;
    public TMP_Text _hpText;
    [SerializeField] private Transform _startPosition;
    //private EnemyObject _enemyObject;

    public void Awake()
    {
        PlayerDiceSpown();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        _diceRoll = FindObjectOfType<EnemyDiceRoll>().GetComponent<EnemyDiceRoll>();
        _panel.SetActive(true);
        _buttonPlay.GameObject().SetActive(true);
        EnemyDiceController = FindObjectOfType<EnemyDiceController>().GetComponent<EnemyDiceController>();
    }

    // Update is called once per frame
    public void PlayGame()
    {
        _panel.SetActive(false);
        _buttonPlay.GameObject().SetActive(false);
        _diceRoll.DiceRollButton();
        StartCoroutine(EnemyDiceController.WaitTwoSeconds());
        EnemyDiceController.isRolled = true;
    }

    public void PlayerDiceSpown()
    {
        GameObject fff = Instantiate(_playerDice, _startPosition, false);
        Debug.Log("FFF " + fff.name + fff.transform.position);
    }




}
