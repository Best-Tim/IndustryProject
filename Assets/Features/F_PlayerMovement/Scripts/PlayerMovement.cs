using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;

    private Vector3 velocity;

    public bool isLocked;
    public bool isInMenu;

    private void Awake()
    {
        isLocked = false;
        isInMenu = false;
    }

    private void Update()
    {
        if (!isLocked && !isInMenu)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}
