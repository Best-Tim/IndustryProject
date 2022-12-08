using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class QuestionUIPopup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] Button buttonYes;
    [SerializeField] Button buttonNo;
    public static QuestionUIPopup Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        Hide();
    }
    public void ShowQuestion(string questionText,Action yesAction,Action noAction)
    {
        gameObject.SetActive(true);
        textMeshProUGUI.text = questionText;
        buttonYes.onClick.AddListener(() => { Hide(); yesAction();});
        buttonNo.onClick.AddListener(() => { Hide();noAction();});
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
