using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Station2 : StationInterface
{
    private ClockHand hand;

    //temperature so it's readable
    [SerializeField]
    private int temperatureNormalized;

    private void Start()
    {
        hand = transform.parent.GetComponentInChildren<ClockHand>(); 
        
    }
    public override void lockCamera(PlayerMovement player)
    {
        if (!isComplete)
        {
            base.lockCamera(player);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            hand.ButtonPressed();
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            hand.ButtonNotPressed();
        }
        TranslateToDegrees();
    }
    public override void reset()
    {
        hand.Reset();
    }
    public override void WinCondition()
    {
    }
    private void TranslateToDegrees()
    {   
        //-135 = 15
        if (checkTempHandBetween(15,16))
        {
            SetNormalizedTemp(0);
        }
        //-105 = 17
        if (checkTempHandBetween(17,18))
        {
            SetNormalizedTemp(15);
        }
        //-75 = 19
        if (checkTempHandBetween(19, 20))
        {
            SetNormalizedTemp(30);
        }
        //-45 = 21
        if (checkTempHandBetween(21, 22))
        {
            SetNormalizedTemp(45);
        }
        //-15 = 23
        if (checkTempHandBetween(23, 24))
        {
            SetNormalizedTemp(60);
        }
        // 15 = 1
        if (checkTempHandBetween(1, 2))
        {
            SetNormalizedTemp(75);
        }
        // 45 = 3
        if (checkTempHandBetween(3, 4))
        {
            SetNormalizedTemp(90);
        }
        // 75 = 5
        if (checkTempHandBetween(5, 6))
        {
            SetNormalizedTemp(105);
        }
        //105 = 7
        if (checkTempHandBetween(7, 8))
        {
            SetNormalizedTemp(120);
        }
        //135 = 9
        if (checkTempHandBetween(9, 10))
        {
            SetNormalizedTemp(135);
        }
    }
    private void SetNormalizedTemp(int n)
    {
        temperatureNormalized = n;
    }
    public bool checkTempHandBetween(int firstInclusive, int lastInclusive)
    {
        if (hand.temp >= firstInclusive && hand.temp <= lastInclusive)
        {
            return true;
        }
        return false;
    }
}
