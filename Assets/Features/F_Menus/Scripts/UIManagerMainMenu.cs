using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIManagerMainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI startText;
    [SerializeField] TextMeshProUGUI optionsText;
    [SerializeField] TextMeshProUGUI quitText;
    [SerializeField] TextMeshProUGUI gameTitleText;
    [SerializeField] TextMeshProUGUI goBackText;
    [SerializeField] Light lightMainMenu;
    [SerializeField] Light lightControlsMenu;

    [SerializeField] AudioClip lightAudio;
    [SerializeField] AudioClip factoryAudio;

    private AudioManager audioManager;

    VertexGradient gradient;

    // Start is called before the first frame update
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Start()
    {
       
        gradient = startText.colorGradient;
        gradient.bottomLeft = new Color(1, 0.9882353f, 0, 1);
        gradient.topLeft = new Color(1, 0.9882353f, 0, 1);
        gradient.topRight = new Color(1, 1, 1, 1);
        gradient.bottomRight = new Color(1, 1, 1, 1);
        //audioSource.Play();
        audioManager.Play("Factory",true);
    }

    public void AnimateStart()
    {
        startText.transform.DOScale(1.1f, 0.5f);       
        startText.colorGradient = gradient;
        lightMainMenu.enabled = true;
        //audioSource.PlayOneShot(lightAudio);
        audioManager.Play("Lightbulb", false);


    }
    public void ExitAnimateStart()
    {
        startText.transform.DOScale(1.0f, 0.5f);
        startText.colorGradient = new VertexGradient(new Color(1,1,1,1));
        lightMainMenu.enabled = false;
        audioManager.Stop("Lightbulb");
    }

    public void AnimateOptions()
    {
        optionsText.transform.DOScale(1.1f, 0.5f);
        optionsText.colorGradient = gradient;
        lightMainMenu.enabled = true;
        audioManager.Play("Lightbulb", false);


    }
    public void ExitAnimateOptions()
    {
        optionsText.transform.DOScale(1.0f, 0.5f);
        optionsText.colorGradient = new VertexGradient(new Color(1, 1, 1, 1));
        lightMainMenu.enabled = false;
        audioManager.Stop("Lightbulb");


    }
    public void AnimateQuitGame()
    {
        quitText.transform.DOScale(1.1f, 0.5f);
        quitText.colorGradient = gradient;
        lightMainMenu.enabled = true;
        audioManager.Play("Lightbulb", false);


    }
   
    public void ExitAnimateQuitGame()
    {
        quitText.transform.DOScale(1.0f, 0.5f);
        quitText.colorGradient = new VertexGradient(new Color(1, 1, 1, 1));
        lightMainMenu.enabled = false;
        audioManager.Stop("Lightbulb");

    }

    public void AnimateGoBackGame()
    {
        goBackText.transform.DOScale(1.1f, 0.5f);
        goBackText.colorGradient = gradient;
        lightControlsMenu.enabled = true;
        audioManager.Play("Lightbulb", false);


    }
    public void ExitAnimateGoBackGame()
    {
        goBackText.transform.DOScale(1.0f, 0.5f);
        goBackText.colorGradient = new VertexGradient(new Color(1, 1, 1, 1));
        lightControlsMenu.enabled = false;
        audioManager.Stop("Lightbulb");


    }

    public void AnimateGameTitle()
    {
        gameTitleText.colorGradient = gradient;
        lightMainMenu.enabled = true;
        audioManager.Play("Lightbulb",false);


    }
    public void ExitAnimateGameTitle()
    {
        gameTitleText.colorGradient = new VertexGradient(new Color(1,1,1,1));
        lightMainMenu.enabled = false;
        audioManager.Stop("Lightbulb");



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
