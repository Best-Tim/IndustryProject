using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensitivity;

    [SerializeField] private Transform playerBody;

    private float rotationX;
    private float rotationY;

    public bool isLocked;
    
    void Awake()
    {       
        isLocked = false;
    }

    void Update()
    {
        if (!isLocked)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);
            transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
