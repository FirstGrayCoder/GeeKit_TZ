using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDiceRoll : MonoBehaviour
{
    public static Rigidbody rb;
    public static Vector3 diceVelocity;
    public bool isActive = true;
    private EnemyDiceController _enemyDiceController;
    GameController _gameController;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.gameObject.SetActive(true);
        _enemyDiceController = FindObjectOfType<EnemyDiceController>().GetComponent<EnemyDiceController>();
        _gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
    }

    void Update()
    {
        diceVelocity = rb.velocity;
        for (int i = 0; i < _enemyDiceController._skills.Length; i++)
        {
            if (_enemyDiceController._skills[i].activeInHierarchy)
            {
                Destroy(gameObject);
                _gameController._rollButton.interactable = true;
            }          
        }
    }

    public void DiceRollButton()
    {
        StartCoroutine(WaitOneSeconds());
        MoveDiceToCenter();
        DiceRoll();
    }
    public void DiceRollButton2()
    {
        MoveDiceToCenter2();
        DiceRoll();
    }

    public void MoveDiceToCenter()
    {
        gameObject.GetComponent<Transform>().localPosition = new Vector3(0.0f, 0.46f, 0.0f) * Time.deltaTime;
        gameObject.GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 0);
    }
    public void MoveDiceToCenter2()
    {
        gameObject.GetComponent<Transform>().localPosition = new Vector3(0.0f, 0.50f, 0.0f) * Time.deltaTime;
        gameObject.GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void DiceRoll()
    {
        rb.isKinematic = false;
        float dirX = Random.Range(0, 80);
        float dirY = Random.Range(0, 16);
        float dirZ = Random.Range(0, 40);
        gameObject.GetComponentInChildren<Transform>().localPosition = new Vector3(0, 2, 0);
        transform.rotation = Quaternion.identity;
        rb.AddForce(transform.up * 300);
        
        rb.AddTorque(dirX, dirY, dirZ);
        if (rb.velocity.y < 0)
        {
            EnemyDiceController.isEnemyRolled = true;
        }
    }

    public IEnumerator WaitOneSeconds()
    {
        yield return new WaitForSeconds(1);
        EnemyDiceController.isEnemyRolled = true;
    }
}
