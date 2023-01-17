using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTutorialTarget : MonoBehaviour {
    private bool isDone;
    public Light targetLight;

    private void Start() {
        isDone = false;
    }

    public bool IsLookedAt() {
        if (!isDone) {
            targetLight.color = Color.green;
            isDone = true;
            return true;
        }
        return false;
    }
}
