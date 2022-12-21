using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTutorialTarget : MonoBehaviour {
    private bool isDone;
    public GameObject lightOn;
    public GameObject lightOff;

    private void Start() {
        isDone = false;
    }

    public bool IsLookedAt() {
        if (!isDone) {
            lightOff.SetActive(false);
            lightOn.SetActive(true);
            isDone = true;
            return true;
        }
        return false;
    }
}
