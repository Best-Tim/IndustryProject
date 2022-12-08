using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHand : MonoBehaviour
{
    public int hourClock;
    private int[] startingPos = { 0, 90, 180, 270 };
    public int random;
    private bool buttonPressed = false;
    public bool startClock = false;

    void clockHandInit()
    {
        random = UnityEngine.Random.Range(0, 3);
        //Rotate(startingPos[random]); 
        gameObject.transform.eulerAngles = new Vector3(0, 0, startingPos[random]);
        random = startingPos[random];
    }
    private void Start()
    {
        clockHandInit();
    }
    public void StartClock()
    {
        startClock = true;
    }
    private void Update()
    {
        if (!buttonPressed && startClock)
        {
            Rotate(20);

            if (Mathf.Round(gameObject.transform.eulerAngles.z) % 30 == 0)
            {
                hourClock = Convert.ToInt32(Mathf.Round(gameObject.transform.eulerAngles.z) / 30);
                //11 = 11
                //12 = 0
                //1 = 1
            }
        }
    }
    public void StopLoop()
    {
        buttonPressed = true;
    }
    public void StartLoop()
    {
        buttonPressed = false;
    }
    private void Rotate(float zValue)
    {
        this.gameObject.transform.Rotate(new Vector3(0, 0, zValue) * Time.deltaTime);

    }
    public void Reset()
    {
        gameObject.transform.eulerAngles = new Vector3(0,0,0);
        hourClock = 0;
        startClock = false;
        clockHandInit();
    }
}
