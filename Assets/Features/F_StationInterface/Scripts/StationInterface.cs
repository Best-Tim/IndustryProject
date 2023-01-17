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
    private AudioManager audioManager;

    public virtual void reset() { }
    public virtual void WinCondition() { }
    
    public void completeStation()
    {
        audioManager = FindObjectOfType<AudioManager>();
        isComplete = true;
        audioManager.Play("CompleteStation2", false);
        SingletonUI.Instance.SetNewGeraldUI($"Good job completing {gameObject.name}! On to the next!",audioManager.GetSoundName("CompleteStation2").audioClip.length);
        lightBulb.GetComponent<MeshRenderer>().material = glowMaterial;
        lightBulb.GetComponent<Light>().intensity = 2;
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
