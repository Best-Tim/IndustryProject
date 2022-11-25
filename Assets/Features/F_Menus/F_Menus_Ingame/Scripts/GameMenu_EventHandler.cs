using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu_EventHandler : MonoBehaviour {
    [SerializeField] private GameObject[] canvasList;
    [SerializeField] private bool IsMenuActive = false;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerCam _playerCam;
    public void FixedUpdate() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            LockPlayer();
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
        UnlockPlayer();
        IsMenuActive = !IsMenuActive;
        for (int i = 0; i < canvasList.Length; i++) {
            canvasList[i].SetActive(false);
        }
    }

    public void LockPlayer() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _playerMovement.isInMenu = true;
        _playerCam.isLocked = true;
    }
    public void UnlockPlayer() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _playerMovement.isInMenu = false;
        _playerCam.isLocked = false;
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
        Cursor.visible = true;
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