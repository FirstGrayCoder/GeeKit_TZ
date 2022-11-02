using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDicerRoll : MonoBehaviour
{
    public static Rigidbody rb;
    public static Vector3 diceVelocity;
    public static bool isActivePD;
    private bool reRoll = false;
    public Transform startPosition2;
    private PlayerDiceController _playerDiceController;
    


    void Start()
    {
        isActivePD = false;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        diceVelocity = rb.velocity;
        if (GameController._rollCount == 0 || GameController.isFighted == true) Destroy(gameObject, 3);
      
    }

    public void DiceRollButton()
    {
        _playerDiceController = FindObjectOfType<PlayerDiceController>().GetComponent<PlayerDiceController>();
        rb.isKinematic = false;
        for (int i = 0; i < _playerDiceController._skills.Length; i++)
        {
            if (_playerDiceController._skills[i].activeInHierarchy)
                _playerDiceController._skills[i].SetActive(false);
        }
        MoveDiceToCenter();
        DiceRoll();
        GameController._rollCount--;
    }

    public IEnumerator WaitTwoSeconds()
    {
        
        yield return new WaitForSeconds(1);
        
    }

    public void MoveDiceToCenter()
    {
            gameObject.GetComponent<Transform>().localPosition = new Vector3(0.0f, 0.46f, 0.0f);
            gameObject.GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void DiceRoll()
    {
        
        float dirX = Random.Range(0, 80);
        float dirY = Random.Range(0, 16);
        float dirZ = Random.Range(0, 40);
        transform.rotation = Quaternion.identity;
        rb.AddForce(transform.up * 300); 
        rb.AddTorque(dirX, dirY, dirZ);
        gameObject.GetComponent<Transform>().localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 2, transform.localPosition.z);
        reRoll = true;
        PlayerDiceController.isRolled = true;
    }
}
