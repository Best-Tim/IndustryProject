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
    
    private GameObject heldObject;
    private Rigidbody heldRB;
    [SerializeField] private Transform heldObjTransform;
    private void Update()
    {
        //Creates a raycast -> on collision with gameObject, pick it up
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null)
            {
                if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit raycastHit, pickUpDistance,
                        pickUpMask))
                {
                    if (raycastHit.transform.gameObject.CompareTag("PickUp"))
                    {
                        PickUpObject(raycastHit.transform.gameObject);
                    }
                    if (raycastHit.transform.gameObject.TryGetComponent(out StationInterface sI))
                    {
                        sI.lockCamera(playerMovement);
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
                float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotationSensitivity;
                float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * rotationSensitivity;
            
                heldObject.transform.RotateAroundLocal(camTransform.up, Mathf.Deg2Rad * mouseX);
                heldObject.transform.RotateAroundLocal(camTransform.right, -Mathf.Deg2Rad * mouseY);
                playerCam.isLocked = true;
                playerMovement.isLocked = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                playerCam.isLocked = false;
                playerMovement.isLocked = false;
            }
            if (Input.GetMouseButtonUp(0))
            {
                playerCam.isLocked = false;
                playerMovement.isLocked = false;
                DropObject();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerMovement.isLocked = false;
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
    void DropObject()
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