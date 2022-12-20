using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHand : MonoBehaviour
{
    public int temp;

    [SerializeField]
    private int rotationSpeed = 360;

    private bool buttonPressed = false;
    void clockHandInit()
    {
        gameObject.transform.eulerAngles = new Vector3(0, 0, 225);
        temp= 0;
    }
    private void Start()
    {
        clockHandInit();
    }
    private void Update()
    {
        if (gameObject.transform.eulerAngles.z >= 135 && gameObject.transform.eulerAngles.z < 225)
        {
            ButtonNotPressed();
        }
        if (buttonPressed)
        {
            Rotate(rotationSpeed);
        }
 
        if (Mathf.Round(gameObject.transform.eulerAngles.z) % 15 == 0)
        {
            temp = Convert.ToInt32(Mathf.Round(gameObject.transform.eulerAngles.z) / 15);
            if (temp == 0)
            {
                temp = 24;
            }
        }
        
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
