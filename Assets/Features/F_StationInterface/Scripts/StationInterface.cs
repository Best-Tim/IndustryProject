using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StationInterface : MonoBehaviour
{
    public GameObject playerPosition;
    public bool isComplete = false;
    public virtual void reset() { }
    public virtual void WinCondition() { }
    public void completeStation()
    {
        isComplete = true;
        SingletonUI.Instance.SetNewGeraldUI($"Good job completing {gameObject.name}! On to the next!");
    }
    public virtual void lockCamera(PlayerMovement player)
    {
        if (!player.isLocked)
        {
            player.gameObject.transform.position = playerPosition.transform.position;
            player.isLocked = true;
        }
    }
}
