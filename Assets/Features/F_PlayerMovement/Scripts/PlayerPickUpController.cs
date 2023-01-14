using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpController : MonoBehaviour
{
    [Header("External objects")]
    [SerializeField] private Transform camTransform;
    [SerializeField] private PlayerCam playerCam;
    [SerializeField] private PlayerMovement playerMovement;
    
    [Header("Pick up variables")]
    public float pickUpDistance = 2f;
    public float pickUpForce = 150f;
    public LayerMask pickUpMask;

    [Header("Rotation variables")]
    public float rotationSensitivity = 200f;

    private bool isAbleToPickup;
    private GameObject heldObject;
    public GameObject rotateObject;
    private Rigidbody heldRB;
    [SerializeField] private Transform heldObjTransform;

    public StationInterface currentStation;

    private AudioManager audioManager;

    private void Awake()
    {
        isAbleToPickup = false;
        rotateObject = null;
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (!playerMovement.isInMenu) {
            PlayerInputs();
        }
    }

    private void PlayerInputs() {
                //Creates a raycast -> on collision with gameObject, pick it up
        if (heldObject == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit raycastHit, pickUpDistance,
                        pickUpMask))
                {
                    //PICK UP OBJECTS
                    if (raycastHit.transform.gameObject.CompareTag("PickUp") && isAbleToPickup)
                    {
                        PickUpObject(raycastHit.transform.gameObject);
                        if (raycastHit.transform.gameObject.TryGetComponent(out RotatableMediator zincHandle))
                        {
                            zincHandle.LockToBowl();
                        }
                    }

                    //LOCKING IN TO A STATION
                    if (raycastHit.transform.gameObject.TryGetComponent(out StationInterface sI))
                    {
                        if (currentStation == null)
                        {
                            sI.lockCamera(playerMovement);
                            isAbleToPickup = true;
                            currentStation = sI;
                            audioManager.Play("LockToStation", false);
                        }
                    }

                    //PRESSING THE BUTTON TO COMPLETE THE STATION
                    if (raycastHit.transform.gameObject.CompareTag("FinishButton") && isAbleToPickup && raycastHit.transform.gameObject.TryGetComponent(out CheckWinCondition checkWinCondition))
                    {
                        checkWinCondition.isPressed = true;
                    }
                    
                    //ROTATING STATIC OBJECTS
                    if (raycastHit.transform.gameObject.CompareTag("Rotatable") && isAbleToPickup)
                    {
                        rotateObject = raycastHit.transform.gameObject;
                    }
                }
            }
            //To be able to rotate static items (e.g. rotating a valve/stiring a handle etc.)
            // if (Input.GetMouseButtonDown(1))
            // {
            //     if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit raycastHit,
            //             pickUpDistance,
            //             pickUpMask))
            //     {
            //         
            //     }
            // }
        }
        else if (heldObject != null)
        {
            MoveObject();
            
            //Rotates the held object when right click is pressed (WHILE PICKED UP!)
            // if (Input.GetMouseButton(1))
            // {
            //     RotateItem(heldObject);
            // }
            // if (Input.GetMouseButtonUp(1))
            // {
            //     playerCam.isLocked = false;
            // }
            if (Input.GetMouseButtonUp(0))
            {
                playerCam.isLocked = false;
                DropObject();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerMovement.isLocked = false;
            isAbleToPickup = false;
            currentStation.reset();
            currentStation = null;
        }

        //If you want to rotate an object and not move it
        if (rotateObject != null && heldObject == null)
        {
            if (Input.GetMouseButton(0))
            {
                RotateRotatable(rotateObject);
            }
            if (Input.GetMouseButtonUp(0))
            {
                playerCam.isLocked = false;
                if (rotateObject.GetComponent<RotatableMediator>())
                {
                    rotateObject.GetComponent<RotatableMediator>().isStiring = false;
                }
                rotateObject = null;
            }
        }
    }

    //Rotates a picked up item in all directions
    public void RotateItem(GameObject gameObject)
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotationSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * rotationSensitivity;
        
        gameObject.transform.RotateAroundLocal(camTransform.up, Mathf.Deg2Rad * mouseX);
        gameObject.transform.RotateAroundLocal(camTransform.right, -Mathf.Deg2Rad * mouseY);
        playerCam.isLocked = true;
        playerMovement.isLocked = true;
    }
    
    
    //Rotates a static item (e.g. rotating a valve around the X axis)
    public void RotateRotatable(GameObject gameObject)
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotationSensitivity;
        gameObject.transform.RotateAroundLocal(camTransform.up, Mathf.Deg2Rad * mouseX);
        playerCam.isLocked = true;
        playerMovement.isLocked = true;
        if (gameObject.GetComponent<RotatableMediator>())
        {
            gameObject.GetComponent<RotatableMediator>().isStiring = true;
        }
    }

    //Pick up mechanic - disables physics
    void PickUpObject(GameObject pickUpObject)
    {
        if (pickUpObject.GetComponent<Rigidbody>())
        {
            heldRB = pickUpObject.GetComponent<Rigidbody>();
            heldRB.useGravity = false;
            heldRB.drag = 10;
            heldRB.constraints = RigidbodyConstraints.FreezeRotation;
            heldRB.transform.parent = heldObjTransform;
            heldObject = pickUpObject;
        }
    }

    //Drops an object - enables physics
    public void DropObject()
    {
        heldRB.useGravity = true;
        heldRB.drag = 1;
        heldRB.constraints = RigidbodyConstraints.None;
        heldRB.transform.parent = null;
        heldObject = null;
    }

    //Locks the held object on the camera transform position
    void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, heldObjTransform.position) > 0.05f)
        {
            Vector3 moveDirection = (heldObjTransform.position - heldObject.transform.position);
            heldRB.AddForce(moveDirection * pickUpForce);
        }
    }
}