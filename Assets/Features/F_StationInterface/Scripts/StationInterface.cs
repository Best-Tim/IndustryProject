using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StationInterface : MonoBehaviour
{
    public GameObject playerPosition;

    private void Start()
    {
        playerPosition = gameObject.transform.GetChild(0).gameObject;
    }
    void reset()
    {

    }

    public void lockCamera(PlayerMovement player)
    {
        player.gameObject.transform.position = playerPosition.transform.position;
        player.isLocked = true;
    }
}
