using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<StationInterface> stations;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        stations.AddRange(FindObjectsOfType<StationInterface>());
        audioManager.Play("FactoryBackground", true);
        //audioManager.Play("WelcomeFactory", false);
        StartCoroutine(audioManager.PlayWelcomingMessages());
        SingletonUI.Instance.SetNewGeraldUI(LocalizationManager.Instance.GetParsedLanguage.localization.factory.intro_txt, audioManager.mainSceneIntroductionSounds[0].audioClip.length);
        SingletonUI.Instance.SetNewGeraldUI(LocalizationManager.Instance.GetParsedLanguage.localization.factory.intro2_txt, audioManager.mainSceneIntroductionSounds[1].audioClip.length);

    }
    private void WelcomingMessages()
    {

    }

}
