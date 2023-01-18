using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizationHelper_MainMenu : MonoBehaviour {
    public TextMeshProUGUI title;
    public TextMeshProUGUI start;
    public TextMeshProUGUI options;
    public TextMeshProUGUI quit;
    

    // Start is called before the first frame update
    void Awake() {
        UpdateText();
    }

    public void SetLanguage(string lang) {
        if (lang == "ENG") {
            LocalizationManager.SetNewLanguage(LocalizationManager.Language.ENG);
            UpdateText();
        } else if (lang == "NL") {
            LocalizationManager.SetNewLanguage(LocalizationManager.Language.NL);
            UpdateText();
        }
    }

    private void UpdateText() {
        title.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu.title_txt;
        start.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu.start_btn;
        options.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu.controls_btn;
        quit.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu.exit_btn;
        
    }
}
