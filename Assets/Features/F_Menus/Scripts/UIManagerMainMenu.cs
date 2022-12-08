using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIManagerMainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameText;    
    [SerializeField] AudioClip lightAudio;
    [SerializeField] AudioClip factoryAudio;
    private AudioManager audioManager;
    VertexGradient gradient;
    
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Start()
    {       
        gradient = gameText.colorGradient;
        gradient.bottomLeft = new Color(1, 0.9882353f, 0, 1);
        gradient.topLeft = new Color(1, 0.9882353f, 0, 1);
        gradient.topRight = new Color(1, 1, 1, 1);
        gradient.bottomRight = new Color(1, 1, 1, 1);        
        audioManager.Play("Factory",true);
    }
    public void TurnOnAnimation(TextMeshProUGUI text)
    {
        text.transform.DOScale(1.1f, 0.5f);       
        text.colorGradient = gradient;           
        audioManager.Play("Lightbulb", false);
    }
    public void TurnOffAnimation(TextMeshProUGUI text)
    {
        text.transform.DOScale(1.0f, 0.5f);
        text.colorGradient = new VertexGradient(new Color(1,1,1,1));        
        audioManager.Stop("Lightbulb");
    }   
    public void TurnOnLight(Light light)
    {
        light.enabled = true;
    }
    public void TurnOffLight(Light light)
    {
        light.enabled = false;
    }
}
