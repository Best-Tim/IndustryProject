using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.XR;

public class ClockHand : MonoBehaviour
{
    public int Temp { get; private set; }
    private bool buttonPressed = false;

    [SerializeField]
    private int rotationSpeed = 135;

    void clockHandInit()
    {
        gameObject.transform.eulerAngles = new Vector3(0, 0, 225.1f);
        Temp= 0;
    }
    private void Start()
    {
        clockHandInit();
    }
    private void Update()
    {
        if (buttonPressed && isInBounds())
        {
            Rotate(rotationSpeed);
        }

        if (!buttonPressed && isInBounds()) 
        {
            Rotate(-rotationSpeed);
        }
        if (!isInBounds())
        {
            clockHandInit();
        }
        setTemp();
    }
    private void setTemp()
    {
        if (Mathf.Round(gameObject.transform.eulerAngles.z) % 15 == 0)
        {
            Temp = Convert.ToInt32(Mathf.Round(gameObject.transform.eulerAngles.z) / 15);
            if (Temp == 0)
            {
                Temp = 24;
            }
        }
    }
    private bool isInBounds()
    {
        float zAngle = gameObject.transform.eulerAngles.z;
        if (zAngle > 225 && zAngle < 495)
        {
            return true;
        }
        if (zAngle <= 135 && zAngle > -135)
        {
            return true;
        }
        return false;
    }
    private bool isOutBounds()
    {
        if (gameObject.transform.eulerAngles.z < -135 || gameObject.transform.eulerAngles.z >= 135)
        {
            return true;
        }
        return false;
    }
    public void ButtonNotPressed()
    {
        buttonPressed = false;
    }
    public void ButtonPressed()
    {
           buttonPressed = true;
    }
    private void Rotate(float zValue)
    {
        this.gameObject.transform.Rotate(new Vector3(0, 0, zValue) * Time.deltaTime);
    }
    public void Reset()
    {
        clockHandInit();
        ButtonNotPressed();
    }
}
