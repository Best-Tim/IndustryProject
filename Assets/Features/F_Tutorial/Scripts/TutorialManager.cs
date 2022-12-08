using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {
    
    [Header("Popup Variables")]
    //Popup variables
    [SerializeField] private Transform popup_holder;
    [SerializeField] private int popUpIndex;
    [Header("References")]
    //References to scene objects
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform lights;
    [SerializeField] private GameObject desk;
    [SerializeField] private Station1 station1;
    
    [Header("Material")]
    //Material for the table objects
    [SerializeField] private Material cotton;
    [SerializeField] private Material metal;

    private List<string> keysPressed;
    private List<GameObject> targetsLookedAt;
    
    [Header("Debug stuff")]
    //Debug stuff
    [SerializeField] private int skipToStep = 0;

    [Header("Text for popup menus")] [SerializeField]
    private List<string> popupTextList;

    PlayerCam playerCam;

    private void Start() {
        playerCam = FindObjectOfType<PlayerCam>();
        popUpIndex = 0;
        keysPressed = new List<string>();
        targetsLookedAt = new List<GameObject>();
        playerMovement.isInMenu = true;
        PopulatePopups();
        #if UNITY_EDITOR
                popUpIndex = skipToStep;
                if(skipToStep > 2)
                    playerMovement.isInMenu = false;
        #endif
    }

    public void PopulatePopups() {
        int maxLength = Mathf.Min(popupTextList.Count, popup_holder.childCount);
        for (int i = 0; i < maxLength; i++) {
            popup_holder.GetChild(i).GetComponent<TextMeshProUGUI>().text = popupTextList[i];
        }
    }

    void Update() 
    {
        for (int i = 0; i < popup_holder.childCount; i++) {
            if (i == popUpIndex) {
                popup_holder.GetChild(i).gameObject.SetActive(true);
            }
            else {
                popup_holder.GetChild(i).gameObject.SetActive(false);
            }
        }

        if (popUpIndex == 0) {
            //Popup 1 will be the camera / look controls
            CameraLookTutorial();
        }

        if (popUpIndex == 1) {
            //Popup 2 will be the movement tutorial
            playerMovement.isInMenu = false;
            MovementTutorial();
        }

        if (popUpIndex == 2) {
            //Popup 3 will be walking up to the station and locking yourself in place
            if (desk.TryGetComponent(out DeskTutorial deskTutorial)) {
                deskTutorial.EnableTutorial();
                DeskLockTutorial(deskTutorial);
            }
        }
        
        if (popUpIndex == 3) {
            //Popup 4 will be about moving around objects
            StationInteractableTutorial();
        }
        
        if (popUpIndex == 4) {
            //Popup 5 will be the victory screen
            playerMovement.isInMenu = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuestionUIPopup.Instance.ShowQuestion("Are you sure you want to quit the game?", () => { SceneManager.LoadScene("Main_Menu"); }, () => { playerCam.isLocked = false; });
            playerCam.isLocked = true;
         
        }
    }

    private bool setShaders;
    private void StationInteractableTutorial() {
        if(!setShaders)
            AddShaderToObject(station1.currentMaterials);

        if (station1.currentZinc.currentCottons.Count >= 2) {
            popUpIndex++;
        }

        
    }

    private void AddShaderToObject(List<GameObject> objects) {
        for (int i = 0; i < objects.Count; i++) {
            for (int j = 0; j < objects[i].transform.childCount; j++) {
                if (objects[i].transform.GetChild(j).TryGetComponent(out MeshRenderer _renderer)) {
                    if (_renderer.transform.name.Contains("Cotton")) {
                        _renderer.material = cotton;
                    }
                }
            }
        }
    }

    private void DeskLockTutorial(DeskTutorial deskTutorial) {
        if (playerMovement.isLocked) {
            popUpIndex++;
            deskTutorial.DisableTutorial();
        }
    }

    private void CameraLookTutorial() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100)) {
            if (hit.transform.TryGetComponent(out LookTutorialTarget lookTutorialTarget)) {
                if (lookTutorialTarget.IsLookedAt()) {
                    targetsLookedAt.Add(hit.transform.gameObject); 
                }
            }
        }
        if (targetsLookedAt.Count == lights.childCount) { popUpIndex++; }
    }

    private void MovementTutorial() {
        if (Input.GetKey(KeyCode.W)) { CheckInput(KeyCode.W, keysPressed); }
        if (Input.GetKey(KeyCode.A)) { CheckInput(KeyCode.A, keysPressed); }
        if (Input.GetKey(KeyCode.S)) { CheckInput(KeyCode.S, keysPressed); }
        if (Input.GetKey(KeyCode.D)) { CheckInput(KeyCode.D, keysPressed); }

        //action to do for first popup
        if (keysPressed.Contains("W") && keysPressed.Contains("A") && keysPressed.Contains("S") && keysPressed.Contains("D")) {
            popUpIndex++;
        }
    }

    private void CheckInput(KeyCode keyCode, List<string> keysPressed) {
        if (Input.GetKey(keyCode)) { keysPressed.Add(keysPressed.Contains(keyCode.ToString()) ? "" : keyCode.ToString()); }
    }
}
