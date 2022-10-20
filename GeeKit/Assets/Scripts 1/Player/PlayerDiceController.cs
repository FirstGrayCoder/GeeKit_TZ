using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiceController : MonoBehaviour
{
    Vector3 diceVelocity;
    public GameObject[] _skills;
    public static bool isRolled = false;

    void FixedUpdate()
    {
        diceVelocity = PlayerDicerRoll.diceVelocity;
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (diceVelocity.x == 0 && diceVelocity.y == 0 && diceVelocity.z == 0 && isRolled == true)
        {
            isRolled = false;
            switch (other.gameObject.name)
            {
                case "Side1":
                    _skills[5].SetActive(true);
                    isRolled = false;
                    break;
                case "Side2":
                    _skills[4].SetActive(true);
                    isRolled = false;
                    break;
                case "Side3":
                    _skills[3].SetActive(true);
                    isRolled = false;
                    break;
                case "Side4":
                    _skills[2].SetActive(true);
                    isRolled = false;
                    break;
                case "Side5":
                    _skills[1].SetActive(true);
                    isRolled = false;
                    break;
                case "Side6":
                    _skills[0].SetActive(true);
                    isRolled = false;
                    break;
            }
        }
    }
}
