using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<StationInterface> stations;

    private void Start()
    {
        stations.AddRange(FindObjectsOfType<StationInterface>());
        SingletonUI.Instance.SetNewGeraldUI(LocalizationManager.Instance.GetParsedLanguage.localization.factory.intro_txt, 5);
    }

}
