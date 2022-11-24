using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu_EventHandler : MonoBehaviour {
    [SerializeField] private GameObject[] canvasList;
    [SerializeField] private bool IsMenuActive = false;
    public void FixedUpdate() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            ActivateIngameMenu();
        }
    }

    public void Event_Resume() {
        DeactivateIngameMenu();
    }

    public void ActivateIngameMenu() {
        if (IsMenuActive) {
            for (int i = 1; i < canvasList.Length; i++) {
                canvasList[i].SetActive(false);
            }
            canvasList[0].gameObject.SetActive(!canvasList[0].activeSelf);
        }
        else {
            canvasList[0].gameObject.SetActive(!canvasList[0].activeSelf);
            IsMenuActive = !IsMenuActive;
        }
    } 
    
    public void DeactivateIngameMenu() {
        IsMenuActive = !IsMenuActive;
        for (int i = 0; i < canvasList.Length; i++) {
            canvasList[i].SetActive(false);
        }
    } 
    
    public void BackButtonCanvas() {
        ActivateIngameMenu();
    }

    public void Event_Controls() {
        //Deactivate main menu
        canvasList[0].SetActive(false);
        //Activate Controls
        canvasList[1].SetActive(true);
    }

    public void Event_Settings() {
        //Deactivate main menu
        canvasList[0].SetActive(false);
        //Activate Settings
        canvasList[2].SetActive(true);
    }

    public void Event_Exit() {
        SceneManager.LoadScene("Main_Menu");
    }

    public void Event_HoverEnter(TextMeshProUGUI t) {
        // t.color = Color.white;
    }

    public void Event_HoverExit(TextMeshProUGUI t) {
        // t.color = Color.black;
    }

    public void PrintMessage(string message) => Debug.Log(message);
}