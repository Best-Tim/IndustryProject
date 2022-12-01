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

    private StationInterface currentStation;

    private void Awake()
    {
        isAbleToPickup = false;
        rotateObject = null;
    }

    private void Update()
    {
        if (!playerMovement.isInMenu) {
            PlayerInputs();
        }
    }

    private void PlayerInputs() {
                //Creates a raycast -> on collision with gameObject, pick it up
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null)
            {
                if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit raycastHit, pickUpDistance,
                        pickUpMask))
                {
                    if (raycastHit.transform.gameObject.CompareTag("PickUp") && isAbleToPickup)
                    {
                        PickUpObject(raycastHit.transform.gameObject);
                    }
                    if (raycastHit.transform.gameObject.TryGetComponent(out StationInterface sI))
                    {
                        sI.lockCamera(playerMovement);
                        isAbleToPickup = true;
                        currentStation = sI;
                    }
                    if (raycastHit.transform.gameObject.CompareTag("Rotatable") && isAbleToPickup)
                    {
                        rotateObject = raycastHit.transform.gameObject;
                    }
                }
            }
        }
        else if (heldObject != null)
        {
            MoveObject();
            
            //Rotates the held object when right click is pressed
            if (Input.GetMouseButton(1))
            {
                RotateItem(heldObject);
            }
            if (Input.GetMouseButtonUp(1))
            {
                playerCam.isLocked = false;
                // playerMovement.isLocked = false;
            }
            if (Input.GetMouseButtonUp(0))
            {
                playerCam.isLocked = false;
                DropObject();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerMovement.isLocked = false;
            isAbleToPickup = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            // currentStation.reset();
            currentStation.completeStation();
        }

        if (rotateObject != null && heldObject == null)
        {
            if (Input.GetMouseButton(1))
            {
                RotateRotatable(rotateObject);
            }
            if (Input.GetMouseButtonUp(1))
            {
                playerCam.isLocked = false;
                rotateObject = null;
            }
        }
    }

    public void RotateItem(GameObject gameObject)
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotationSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * rotationSensitivity;
        
        gameObject.transform.RotateAroundLocal(camTransform.up, Mathf.Deg2Rad * mouseX);
        gameObject.transform.RotateAroundLocal(camTransform.right, -Mathf.Deg2Rad * mouseY);
        playerCam.isLocked = true;
        playerMovement.isLocked = true;
    }
    
    public void RotateRotatable(GameObject gameObject)
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotationSensitivity;
        
        gameObject.transform.RotateAroundLocal(camTransform.up, Mathf.Deg2Rad * mouseX);
        playerCam.isLocked = true;
        playerMovement.isLocked = true;
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
        if (Vector3.Distance(heldObject.transform.position, heldObjTransform.position) > 0.1f)
        {
            Vector3 moveDirection = (heldObjTransform.position - heldObject.transform.position);
            heldRB.AddForce(moveDirection * pickUpForce);
        }
    }
}