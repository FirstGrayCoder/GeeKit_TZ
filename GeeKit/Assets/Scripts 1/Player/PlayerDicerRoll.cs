using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDicerRoll : MonoBehaviour
{
    public static Rigidbody rb;
    public static Vector3 diceVelocity;
    private static Vector3 startPosition;
    public static bool isActivePD;
    //private PlayerDiceController playerDiceController;
    private bool reRoll = false;
    public Transform startPosition2;

    void Start()
    {
        //playerDiceController = FindObjectOfType<PlayerDiceController>();
        //Debug.Log("playerDiceControl " + playerDiceController._skills.Length);

        startPosition = transform.localPosition;
        isActivePD = false;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        //rb.gameObject.SetActive(false);
        
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        diceVelocity = rb.velocity;
    }

    public void DiceRollButton(PlayerDiceController playerDiceController)
    {
        rb.isKinematic = false;
        for (int i = 0; i < playerDiceController._skills.Length; i++)
        {
            if (playerDiceController._skills[i].activeInHierarchy)
                playerDiceController._skills[i].SetActive(false);
            Debug.Log("lksdklfslkflkf");
        }
        float dirX = Random.Range(60, 800);
        float dirY = Random.Range(7, 500);
        float dirZ = Random.Range(100, 1000);
        transform.rotation = Quaternion.identity;
        if (reRoll == false)
        { rb.AddForce(transform.right * 500); }
        else { rb.AddForce(transform.up * 800); }
        rb.AddTorque(dirX, dirY, dirZ);
        gameObject.GetComponent<Transform>().localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+2, transform.localPosition.z);
        PlayerDiceController.isRolled = true;
        reRoll = true;
        
    }


}
