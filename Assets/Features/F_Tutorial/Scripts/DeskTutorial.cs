using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskTutorial : MonoBehaviour {
    [SerializeField] private float outlineWidth = 0.01f;

    public void EnableTutorial() {
        if (TryGetComponent(out MeshRenderer meshRenderer)) {
            meshRenderer.material.SetFloat("_OutlineWidth", outlineWidth);
        }
    }
    public void DisableTutorial() {
        if (TryGetComponent(out MeshRenderer meshRenderer)) {
            meshRenderer.material.SetFloat("_OutlineWidth", 0f);
        }
    }
}
