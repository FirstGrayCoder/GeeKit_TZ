using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiceController : MonoBehaviour
{
    Vector3 diceVelocity;
    [SerializeField] public GameObject[] _skills;
    private EnemyObject _enemyObject;
    public static bool isEnemyRolled = false;
    public static int demage;

    void Start()
    {
        _enemyObject = GetComponent<EnemyObject>();
    }

    void Update()
    {
        diceVelocity = EnemyDiceRoll.diceVelocity;
    }

    public void OnTriggerStay(Collider other)
    {
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && isEnemyRolled == true)
        {
            switch (other.gameObject.name)
            {
                case "Side1":
                    _skills[5].SetActive(true);
                    isEnemyRolled = false;
                    break;
                case "Side2":
                    _skills[4].SetActive(true);
                    break;
                case "Side3":
                    _skills[3].SetActive(true);
                    isEnemyRolled = false;
                    break;
                case "Side4":
                    _skills[2].SetActive(true);
                    isEnemyRolled = false;
                    break;
                case "Side5":
                    _skills[1].SetActive(true);
                    isEnemyRolled = false;
                    break;
                case "Side6":
                    _skills[0].SetActive(true);
                    isEnemyRolled = false;
                    break;
            }
            isEnemyRolled = false;
        }
    }
}
