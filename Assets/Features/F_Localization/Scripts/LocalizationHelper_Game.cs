using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizationHelper_Game : MonoBehaviour {
    public TextMeshProUGUI title;
    public TextMeshProUGUI start;
    public TextMeshProUGUI options;
    public TextMeshProUGUI quit;
    public TextMeshProUGUI tutorial;

    // Start is called before the first frame update
    void Awake() {
        title.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu.title_txt;
        start.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu.start_btn;
        options.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu.controls_btn;
        quit.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu.exit_btn;
        tutorial.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu.tutorial_btn;
    }
}
