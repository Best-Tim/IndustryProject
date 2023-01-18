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
        audioManager.Play("WelcomeFactory", false);
        SingletonUI.Instance.SetNewGeraldUI(
            LocalizationManager.Instance.GetParsedLanguage.localization.factory.intro_txt, 5);
    }

}
