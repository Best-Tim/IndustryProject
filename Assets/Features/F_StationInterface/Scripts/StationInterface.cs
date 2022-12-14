using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StationInterface : MonoBehaviour
{
    public GameObject playerPosition;
    public bool isComplete = false;

    private PlayerMovement lockedPlayer;

    public virtual void Reset() { }
    public virtual void WinCondition() { }

    public void CompleteStation()
    {
        isComplete = true;
    }

    public virtual void LockCamera(PlayerMovement player)
    {
        player.gameObject.transform.position = playerPosition.transform.position;
        player.isLocked = true;
        lockedPlayer = player;
    }
}
