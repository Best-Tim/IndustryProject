using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SingletonUI : MonoBehaviour
{
    private IEnumerator notificationCoroutine;
    private static SingletonUI instance;

    //text limit size: 80 chars
    [SerializeField] private TextMeshProUGUI notificationText;
    //make private public for testing
    [SerializeField] private float fadeTime;
    [SerializeField] private List<Image> images;
    [SerializeField] private RawImage gerald;

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
    //call UI with default timer (5 seconds)
    public void SetNewGeraldUI(string message)
    {
        if (notificationCoroutine != null)
        {
            StopCoroutine(notificationCoroutine);
        }
        notificationCoroutine = FadeOutNotification(message);
        StartCoroutine(notificationCoroutine);
    }
    //call UI with custom timer - untested
    public void SetNewGeraldUI(string message, float n)
    {
        fadeTime = n;
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
            notificationText.color = fadeOut(notificationText.color, t);

            foreach (var i in images)
            {
                i.color = fadeOut(i.color, t);
            }
            gerald.color = fadeOut(gerald.color, t);

            yield return null;
        }
    }

    private Color fadeOut(Color c, float t)
    {
        return new Color(
                c.r,
                c.g,
                c.b,
                Mathf.Lerp(1f, 0f, t / fadeTime));
    }
}
