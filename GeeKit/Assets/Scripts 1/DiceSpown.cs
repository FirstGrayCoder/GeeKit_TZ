using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpown : MonoBehaviour
{
    [SerializeField] private GameObject dice;
    [SerializeField] private Transform spownPoint;


    void Start()
    {
        PlayerSpown();
    }

    public void PlayerSpown()
    {
        GameObject fff = Instantiate(dice, spownPoint.localPosition, Quaternion.Euler(45, 0, 0));
    }
}

