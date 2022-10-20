using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiceRoll : MonoBehaviour
{
    public static Rigidbody rb;
    public static Vector3 diceVelocity;
    public bool isActive = true;
    //public static bool isRolled;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        diceVelocity = rb.velocity;
    }

    public void DiceRollButton()
    {
        rb.isKinematic = false;
        float dirX = Random.Range(0, 800);
        float dirY = Random.Range(0, 1600);
        float dirZ = Random.Range(0, 400);
        gameObject.GetComponentInChildren<Transform>().localPosition = new Vector3(0, 2, 0);
        transform.rotation = Quaternion.identity;
        rb.AddForce(transform.right * 600);
        rb.AddTorque(dirX, dirY, dirZ);
    }
}
