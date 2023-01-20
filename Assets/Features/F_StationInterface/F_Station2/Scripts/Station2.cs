using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Station2 : StationInterface
{
    private ClockHand hand;
    private ParticleController particleController;
    private OvenCollider OvenCollider;
    private string[] particles = {"Fire","Smoke","Sparks"};
    private bool UIPlayed = false;
    private AudioManager audioManager;

    //temperature so it's readable
    [SerializeField]
    private int temperatureNormalized;
    [SerializeField]
    private float timerValue = 3f;
    private float timerFunctional;
    private int sequenceTracker;
    private void Start()
    {
        hand = transform.parent.GetComponentInChildren<ClockHand>(); 
        particleController = transform.parent.GetComponentInChildren<ParticleController>();
        OvenCollider = gameObject.GetComponentInChildren<OvenCollider>(); 
        timerFunctional = timerValue;
    }
    public override void lockCamera(PlayerMovement player)
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (!isComplete && !player.isLocked)
        {
            audioManager.Play("OvenGreeting", false);
            base.lockCamera(player);
            if (!UIPlayed)
            {
                SingletonUI.Instance.SetNewGeraldUI("Oh so you are using the oven, careful sometimes it leaks...",audioManager.GetSoundName("OvenGreeting").audioClip.length +1f);
            }
            UIPlayed = true;
        }
    }
    private void Update()
    {
        if (OvenCollider.carbonPlaced)
        {
            randomizedSequence();
        }
        //for testing
        if (Input.GetKeyDown(KeyCode.Y))
        {
            hand.ButtonPressed();
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            hand.ButtonNotPressed();
        }
        TranslateToDegrees();

        WinCondition();
    }
    public override void reset()
    {
        hand.Reset();
        OvenCollider.ResetOven();
    }
    public override void WinCondition()
    {
        //CLEAN THIS CODE PLEASE YOUR SANITY DEPENDS ON IT
        if (!isComplete)
        {
            if (sequenceTracker == 1)
            {
                if (temperatureNormalized >= 30 && temperatureNormalized <= 60)
                {
                    if (timerFunctional > 0)
                    {
                        timerFunctional -= Time.deltaTime;
                    }
                    else
                    {
                        timerFunctional = 0;
                    }
                    if (timerFunctional == 0)
                    {
                    
                        completeStation();
                    }
                }
                else
                {
                    timerFunctional = timerValue;
                }
            }
            if (sequenceTracker == 2)
            {
                if (temperatureNormalized >= 60 && temperatureNormalized <= 90)
                {
                    if (timerFunctional > 0)
                    {
                        timerFunctional -= Time.deltaTime;
                    }
                    else
                    {
                        timerFunctional = 0;
                    }
                    if (timerFunctional == 0)
                    {
                    
                        completeStation();
                    }
                }
                else
                {
                    timerFunctional = timerValue;
                }
            }

            if (sequenceTracker == 3)
            {
                if (temperatureNormalized >= 90 && temperatureNormalized <= 120)
                {
                    if (timerFunctional > 0)
                    {
                        timerFunctional -= Time.deltaTime;
                    }
                    else
                    {
                        timerFunctional = 0;
                    }

                    if (timerFunctional == 0)
                    {

                        completeStation();
                    }
                }
                else
                {
                    timerFunctional = timerValue;
                }
            }
        }
    }
    private void randomizedSequence()
    {
        int r = Random.Range(0, particles.Length);

        if (r == 0)
        {
            particleController.PlayParticleSequence("Fire", "Smoke", "Sparks");
            sequenceTracker = 1;
        }
        if (r == 1)
        {
            particleController.PlayParticleSequence("Smoke", "Sparks", "Fire");
            sequenceTracker = 2;
        }
        if (r == 2)
        {
            particleController.PlayParticleSequence("Sparks", "Fire", "Smoke");
            sequenceTracker = 3;
        }
        OvenCollider.carbonPlaced = false;
    }
    //clean this, maybe loop with presets and increase counter by 15 intervals
    private void TranslateToDegrees()
    {   
        //-135 = 15
        if (checkTempHandBetween(15,16))
        {
            SetNormalizedTemp(0);
        }
        //-105 = 17
        if (checkTempHandBetween(17,18))
        {
            SetNormalizedTemp(15);
        }
        //-75 = 19
        if (checkTempHandBetween(19, 20))
        {
            SetNormalizedTemp(30);
        }
        //-45 = 21
        if (checkTempHandBetween(21, 22))
        {
            SetNormalizedTemp(45);
        }
        //-15 = 23
        if (checkTempHandBetween(23, 24))
        {
            SetNormalizedTemp(60);
        }
        // 15 = 1
        if (checkTempHandBetween(1, 2))
        {
            SetNormalizedTemp(75);
        }
        // 45 = 3
        if (checkTempHandBetween(3, 4))
        {
            SetNormalizedTemp(90);
        }
        // 75 = 5
        if (checkTempHandBetween(5, 6))
        {
            SetNormalizedTemp(105);
        }
        //105 = 7
        if (checkTempHandBetween(7, 8))
        {
            SetNormalizedTemp(120);
        }
        //135 = 9
        if (checkTempHandBetween(9, 10))
        {
            SetNormalizedTemp(135);
        }
    }
    private void SetNormalizedTemp(int n)
    {
        temperatureNormalized = n;
    }
    public bool checkTempHandBetween(int firstInclusive, int lastInclusive)
    {
        if (hand.Temp >= firstInclusive && hand.Temp <= lastInclusive)
        {
            return true;
        }
        return false;
    }
}
