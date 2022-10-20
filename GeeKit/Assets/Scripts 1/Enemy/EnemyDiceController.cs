using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiceController : MonoBehaviour
{
    Vector3 diceVelocity;
    [SerializeField] private GameObject[] _skills;
    private EnemyObject _enemyObject;
    public bool isRolled = false;
    // Start is called before the first frame update
    void Start()
    {
        _enemyObject = GetComponent<EnemyObject>();

    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = EnemyDiceRoll.diceVelocity;
    }

    public void OnTriggerStay(Collider other)
    {
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && isRolled == true)
        {
            switch (other.gameObject.name)
            {
                case "Side1":
                    _skills[5].SetActive(true);
                    EnemyObject.demage = 40;
                    StartCoroutine(WaitTwoSeconds());
                    EnemyDiceRoll.rb.gameObject.SetActive(false);
                    PlayerDicerRoll.rb.gameObject.SetActive(true);
                    isRolled = false;
                    break;
                case "Side2":
                    _skills[4].SetActive(true);
                    EnemyObject.demage = 20;
                    StartCoroutine(WaitTwoSeconds());
                    EnemyDiceRoll.rb.gameObject.SetActive(false);
                    PlayerDicerRoll.rb.gameObject.SetActive(true);
                    isRolled = false;
                    break;
                case "Side3":
                    _skills[3].SetActive(true);
                    EnemyObject.demage = 40;
                    StartCoroutine(WaitTwoSeconds());
                    EnemyDiceRoll.rb.gameObject.SetActive(false);
                    PlayerDicerRoll.rb.gameObject.SetActive(true);
                    isRolled = false;
                    break;
                case "Side4":
                    _skills[2].SetActive(true);
                    EnemyObject.demage = 20;
                    StartCoroutine(WaitTwoSeconds());
                    EnemyDiceRoll.rb.gameObject.SetActive(false);
                    PlayerDicerRoll.rb.gameObject.SetActive(true);
                    isRolled = false;
                    break;
                case "Side5":
                    _skills[1].SetActive(true);
                    EnemyObject.demage = 40;
                    StartCoroutine(WaitTwoSeconds());
                    EnemyDiceRoll.rb.gameObject.SetActive(false);
                    PlayerDicerRoll.rb.gameObject.SetActive(true);
                    isRolled = false;
                    break;
                case "Side6":
                    _skills[0].SetActive(true);
                    EnemyObject.demage = 20;
                    StartCoroutine(WaitTwoSeconds());
                    EnemyDiceRoll.rb.gameObject.SetActive(false);
                    PlayerDicerRoll.rb.gameObject.SetActive(true);
                    isRolled = false;
                    break;
            }
        }
    }
    public IEnumerator WaitTwoSeconds()
    {
        yield return new WaitForSeconds(4);
    }

}
