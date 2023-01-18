using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizationHelper_MenuIngame : MonoBehaviour {
    //Popup menu
    public TextMeshProUGUI questiontext;
    public TextMeshProUGUI yesbutton;
    public TextMeshProUGUI nobutton;
    
    
    public TextMeshProUGUI[] titles;
    public TextMeshProUGUI resume;
    public TextMeshProUGUI quit;
    public TextMeshProUGUI[] backs;
    //Ingame Menu ESC
    public TextMeshProUGUI controls;
    public TextMeshProUGUI settings;
    //Ingame Menu Controls
    public TextMeshProUGUI controlsR;

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
        questiontext.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu_ingame.questiontxt;
        yesbutton.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu_ingame.yesbutton;
        nobutton.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu_ingame.nobutton;
        
        foreach (TextMeshProUGUI title in titles) {
            title.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu_ingame.title_txt;
        }

        resume.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu_ingame.resume_txt;
        quit.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu_ingame.quit_txt;
        foreach (TextMeshProUGUI back in backs) {
            back.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu_ingame.back_txt;
        }

        controls.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu_ingame.controls_txt;
        settings.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu_ingame.settings_txt;
        
        controlsR.text = LocalizationManager.Instance.GetParsedLanguage.localization.menu_ingame.controlsR_txt;
    }
}
