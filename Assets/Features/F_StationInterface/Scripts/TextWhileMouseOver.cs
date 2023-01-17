using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class TextWhileMouseOver : MonoBehaviour
{
    public TMP_Text hiddenText;

    private void Start()
    {
        hiddenText.gameObject.SetActive(false);
    }
    private void OnMouseOver()
    {
        hiddenText.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        hiddenText.gameObject.SetActive(false);
    }
}
