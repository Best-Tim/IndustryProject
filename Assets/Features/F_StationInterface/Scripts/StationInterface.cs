using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StationInterface : MonoBehaviour
{
    public GameObject playerPosition;
    private bool isComplete = false;

    public virtual void reset() { }

    public void completeStation()
    {
        isComplete = true;
    }

    public virtual void lockCamera(PlayerMovement player)
    {
        player.gameObject.transform.position = playerPosition.transform.position;
        player.isLocked = true;
    }
    public virtual void WinCondition() { }
}
