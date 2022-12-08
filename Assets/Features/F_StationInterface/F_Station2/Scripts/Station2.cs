using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Station2 : StationInterface
{
    private ClockHand hand;

    [SerializeField]
    private Green green;

    [SerializeField]
    private Station1 station1;

    private void Start()
    {
        hand = GetComponentInChildren<ClockHand>(); 
        
    }
    public override void lockCamera(PlayerMovement player)
    {
        base.lockCamera(player);
        hand.StartClock();
    }
    private void Update()
    {
        //remove inputs
        if (Input.GetKey(KeyCode.P))
        {
            this.reset();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            hand.StopLoop();

        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            hand.StartLoop();
            if (checkWinCon())
            {
                Debug.Log("you win");
                green.CompleteStation();
            }
        }
    }
    public override void reset()
    {
        hand.Reset();
    }
    public override void WinCondition()
    {
    }
    private bool checkWinCon()
    {

        //int scale = station1.currentZinc.scale;

        //remove hard coded int for station 1 reference when merged
        int scale = 3;
        if (scale == 3)
        {
            //north
            if (hand.random == 0)
            {
                if (checkHandPosition(1, 3))
                {
                    return false;
                }
                if (checkHandPosition(4, 6))
                {
                    return false;
                }
                if (checkHandPosition(7, 9))
                {
                    return false;
                }
                if (checkHandPosition(10, 12))
                {
                    return true;
                }
            }
            //east
            if (hand.random == 90)
            {
                if (checkHandPosition(1, 3))
                {
                    return false;
                }
                if (checkHandPosition(4, 6))
                {
                    return false;
                }
                if (checkHandPosition(7, 9))
                {
                    return true;
                }
                if (checkHandPosition(10, 12))
                {
                    return false;
                }
            }
            //south
            if (hand.random == 180)
            {
                if (checkHandPosition(1, 3))
                {
                    return false;
                }
                if (checkHandPosition(4, 6))
                {
                    return true;
                }
                if (checkHandPosition(7, 9))
                {
                    return false;
                }
                if (checkHandPosition(10, 12))
                {
                    return false;
                }
            }
            //west
            if (hand.random == 270)
            {
                if (checkHandPosition(1, 3))
                {
                    return true;
                }
                if (checkHandPosition(4, 6))
                {
                    return false;
                }
                if (checkHandPosition(7, 9))
                {
                    return false;
                }
                if (checkHandPosition(10, 12))
                {
                    return false;
                }
            }
        }
        if (scale == 2)
        {
            //north
            if (hand.random == 0)
            {
                if (checkHandPosition(1, 3))
                {
                    return true;
                }
                if (checkHandPosition(4, 6))
                {
                    return false;
                }
                if (checkHandPosition(7, 9))
                {
                    return false;
                }
                if (checkHandPosition(10, 12))
                {
                    return false;
                }
            }
            //east
            if (hand.random == 90)
            {
                if (checkHandPosition(1, 3))
                {
                    return false;
                }
                if (checkHandPosition(4, 6))
                {
                    return true;
                }
                if (checkHandPosition(7, 9))
                {
                    return false;
                }
                if (checkHandPosition(10, 12))
                {
                    return false;
                }
            }
            //south
            if (hand.random == 180)
            {
                if (checkHandPosition(1, 3))
                {
                    return false;
                }
                if (checkHandPosition(4, 6))
                {
                    return false;
                }
                if (checkHandPosition(7, 9))
                {
                    return true;
                }
                if (checkHandPosition(10, 12))
                {
                    return false;
                }
            }
            //west
            if (hand.random == 270)
            {
                if (checkHandPosition(1, 3))
                {
                    return false;
                }
                if (checkHandPosition(4, 6))
                {
                    return false;
                }
                if (checkHandPosition(7, 9))
                {
                    return false;
                }
                if (checkHandPosition(10, 12))
                {
                    return true;
                }
            }
        }
        if (scale == 1)
        {
            //north
            if (hand.random == 0)
            {
                if (checkHandPosition(1, 3))
                {
                    return false;
                }
                if (checkHandPosition(4, 6))
                {
                    return false;
                }
                if (checkHandPosition(7, 9))
                {
                    return true;
                }
                if (checkHandPosition(10, 12))
                {
                    return false;
                }
            }
            //east
            if (hand.random == 90)
            {
                if (checkHandPosition(1, 3))
                {
                    return false;
                }
                if (checkHandPosition(4, 6))
                {
                    return false;
                }
                if (checkHandPosition(7, 9))
                {
                    return false;
                }
                if (checkHandPosition(10, 12))
                {
                    return true;
                }
            }
            //south
            if (hand.random == 180)
            {
                if (checkHandPosition(1, 3))
                {
                    return false;
                }
                if (checkHandPosition(4, 6))
                {
                    return true;
                }
                if (checkHandPosition(7, 9))
                {
                    return false;
                }
                if (checkHandPosition(10, 12))
                {
                    return false;
                }
            }
            //west
            if (hand.random == 270)
            {
                if (checkHandPosition(1, 3))
                {
                    return true;
                }
                if (checkHandPosition(4, 6))
                {
                    return false;
                }
                if (checkHandPosition(7, 9))
                {
                    return false;
                }
                if (checkHandPosition(10, 12))
                {
                    return false;
                }
            }
        }
        return false;
    }

    public bool checkHandPosition(int firstInclusive, int lastInclusive)
    {
        if (hand.hourClock >= firstInclusive && hand.hourClock <= lastInclusive)
        {
            return true;
        }
        return false;
    }
}
