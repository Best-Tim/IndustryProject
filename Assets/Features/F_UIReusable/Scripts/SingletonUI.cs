using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SingletonUI : MonoBehaviour
{
    private IEnumerator notificationCoroutine;
    private static SingletonUI instance;

    [SerializeField] private TextMeshProUGUI notificationText;
    //make private public for testing
    [SerializeField] public float fadeTime;
    public static SingletonUI Instance
    {
        get
        {
            if(instance!=null)
            {
                return instance;
            }

            instance = FindObjectOfType<SingletonUI>();

            if (instance !=null)
            {
                return instance;
            }

            CreateNewInstance();
            return instance;
        }
    }

    public static SingletonUI CreateNewInstance()
    {
        SingletonUI singletonUIPrefab = Resources.Load<SingletonUI>("SingletonUI");
        instance = Instantiate(singletonUIPrefab);
        return instance;
    }

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetNewNotification(string message)
    {
        if(notificationCoroutine != null)
        {
            StopCoroutine(notificationCoroutine);
        }
        notificationCoroutine = FadeOutNotification(message);
        StartCoroutine(notificationCoroutine);
    }

    private IEnumerator FadeOutNotification(string message)
    {
        notificationText.text = message;
        float t = 0;
        while (t<fadeTime)
        {
            t += Time.unscaledDeltaTime;
            notificationText.color = new Color(
                notificationText.color.r,
                notificationText.color.g,
                notificationText.color.b,
                Mathf.Lerp(1f,0f, t/fadeTime));
            yield return null;
        }
    }
}
