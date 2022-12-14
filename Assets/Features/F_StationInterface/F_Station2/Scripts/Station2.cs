using DG.Tweening;
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
    private Station1 _station1;

    private void Start()
    {
        hand = GetComponentInChildren<ClockHand>();
        if (_station1 == null)
        {
            _station1 = FindObjectOfType<Station1>();
        }
    }
    public override void LockCamera(PlayerMovement player)
    {
        if (!isComplete)
        {
            base.LockCamera(player);
            hand.StartClock();
        }
    }
    private void Update()
    {
        WinCondition();
    }
    public override void Reset()
    {
        hand.Reset();
        hand.StopClock();
    }
    public override void WinCondition()
    {

        if (Input.GetKeyDown(KeyCode.Y))
        {
            hand.ButtonPressed();
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            hand.ButtonUNpressed();
            if (checkWinCon())
            {
                Debug.Log("you win");
                base.CompleteStation();
                hand.ButtonPressed();
                green.MakeGreen();
            }
            else
            {
                green.MakeRed();
            }
        }
    }
    private bool checkWinCon()
    {

        int scale = _station1.currentZinc.scale;

        if (scale == 3)
        {
            //north
            if (hand.random == 0)
            {
                if (checkHandPosition(10, 12))
                {
                    return true;
                }
                else return false;
            }
            //east
            if (hand.random == 90)
            {
                if (checkHandPosition(7, 9))
                {
                    return true;
                }
                else return false;
            }
            //south
            if (hand.random == 180)
            {
                if (checkHandPosition(4, 6))
                {
                    return true;
                }
                else return false;
            }
            //west
            if (hand.random == 270)
            {
                if (checkHandPosition(1, 3))
                {
                    return true;
                }
                else return false;
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
                else return false;
            }
            //east
            if (hand.random == 90)
            {
                if (checkHandPosition(4, 6))
                {
                    return true;
                }
                else return false;
            }
            //south
            if (hand.random == 180)
            {
                if (checkHandPosition(7, 9))
                {
                    return true;
                }
                else return false;
            }
            //west
            if (hand.random == 270)
            {
                if (checkHandPosition(10, 12))
                {
                    return true;
                }
                else return false;
            }
        }
        if (scale == 1)
        {
            //north
            if (hand.random == 0)
            {
                if (checkHandPosition(7, 9))
                {
                    return true;
                }
                else return false;
            }
            //east
            if (hand.random == 90)
            {
                if (checkHandPosition(10, 12))
                {
                    return true;
                }
                else return false;
            }
            //south
            if (hand.random == 180)
            {
                if (checkHandPosition(4, 6))
                {
                    return true;
                }
                else return false;
            }
            //west
            if (hand.random == 270)
            {
                if (checkHandPosition(1, 3))
                {
                    return true;
                }
                else return false;
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
