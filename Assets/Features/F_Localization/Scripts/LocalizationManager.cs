using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class LocalizationManager : MonoBehaviour {
    private static LocalizationManager instance;

    public static LocalizationManager Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<LocalizationManager>();

                if (instance == null) {
                    GameObject go = new GameObject();
                    go.name = "LocalizationManager";
                    instance = go.AddComponent<LocalizationManager>();

                    DontDestroyOnLoad(go);
                }
            }


            return instance;
        }
    }

    public JSONParser GetParsedLanguage;
    private TextAsset Local_NL;
    private TextAsset Local_ENG;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Local_NL = Resources.Load<TextAsset>("Local_NL");
        Local_ENG = Resources.Load<TextAsset>("Local_ENG");

        if (Local_NL && Local_ENG) {
            if (lang == Language.NL) {
                GetParsedLanguage = new JSONParser(Local_NL);
            }
            else if (lang == Language.ENG) {
                GetParsedLanguage = new JSONParser(Local_ENG);
            }
        }
    }

    private void Update() {
        if (Input.GetKey(KeyCode.L)) {
            if (lang == Language.NL) {
                SetNewLanguage(Language.ENG);
            }
            else if (lang == Language.ENG) {
                SetNewLanguage(Language.NL);
            }
        }
    }

    public static void SetNewLanguage(Language lang) {
        if (lang == Language.NL) {
            Instance.GetParsedLanguage = new JSONParser(Instance.Local_NL);
        }
        else if (lang == Language.ENG) {
            Instance.GetParsedLanguage = new JSONParser(Instance.Local_ENG);
        }
    }

    public enum Language {
        NL,
        ENG
    }

    private static Language lang = Language.NL;

    public static Language Lang {
        get => lang;
        set => lang = value;
    }
}