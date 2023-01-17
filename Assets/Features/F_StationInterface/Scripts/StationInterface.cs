using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StationInterface : MonoBehaviour
{
    public GameObject playerPosition;
    public bool isComplete = false;
    public GameObject lightBulb;
    public Material glowMaterial;

    public virtual void reset() { }
    public virtual void WinCondition() { }

    public void completeStation()
    {
        isComplete = true;
        lightBulb.GetComponent<MeshRenderer>().material = glowMaterial;
        lightBulb.GetComponent<Light>().intensity = 2;
    }

    public virtual void lockCamera(PlayerMovement player)
    {
        player.gameObject.transform.position = playerPosition.transform.position;
        player.isLocked = true;
    }
}
