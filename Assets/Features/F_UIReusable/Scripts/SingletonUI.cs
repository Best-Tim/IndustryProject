using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

[System.Serializable]
public class MessageDoneEventWithID : UnityEvent<int>
{
}
public class SingletonUI : MonoBehaviour
{
    private IEnumerator notificationCoroutine;
    private static SingletonUI instance;
    private Queue<IEnumerator> queue = new Queue<IEnumerator>();

    public delegate void OnMessageDone<T>(object sender, int id);
    public static event OnMessageDone<int> onMessageDone;
    
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
        
        instance.GetComponent<Canvas>().worldCamera = GetUICamera();
        return instance;
    }

    private static Camera GetUICamera() {
        foreach (Camera allCamera in Camera.allCameras) {
            if (allCamera.CompareTag("UICamera")) {
                return allCamera;
            }
        }
        return Camera.main;
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
        checkCoroutine(notificationCoroutine);
        notificationCoroutine = FadeOutNotification(message);
        queue.Enqueue(notificationCoroutine);
    }
    //call UI with custom timer
    public void SetNewGeraldUI(string message, float n)
    {
        checkCoroutine(notificationCoroutine);
        notificationCoroutine = FadeOutNotification(message, n);
        queue.Enqueue(notificationCoroutine);
    }
    //duplicate code
    private void checkCoroutine(IEnumerator coroutine)
    {
        if (coroutine!=null)
        {
            StopCoroutine(coroutine);
        }
    }
    //coroutine for notification fade out default timer
    private IEnumerator FadeOutNotification(string message)
    {
        notificationText.text = message;
        float t = 0;
        while (t<fadeTime)
        {
            t += Time.deltaTime;
            notificationText.color = fadeOut(notificationText.color, t);

            foreach (var i in images)
            {
                i.color = fadeOut(i.color, t);
            }
            gerald.color = fadeOut(gerald.color, t);

            yield return null;
        }
    }
    //coroutine for notification fade out set timer
    private IEnumerator FadeOutNotification(string message, float n)
    {
        notificationText.text = message;
        float t = 0;
        while (t < n)
        {
            t += Time.deltaTime;
            notificationText.color = fadeOut(notificationText.color, t, n);

            foreach (var i in images)
            {
                i.color = fadeOut(i.color, t, n);
            }
            gerald.color = fadeOut(gerald.color, t, n);

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
    private Color fadeOut(Color c, float t, float n)
    {
        return new Color(
                c.r,
                c.g,
                c.b,
                Mathf.Lerp(1f, 0f, t / n));
    }
    private void Start()
    {
        StartCoroutine(CoroutineCoordinator());
    }
    
    IEnumerator CoroutineCoordinator()
    {
            int n = 1;
            while (queue.Count >0)
            {
                yield return StartCoroutine(queue.Dequeue());
            }
            onMessageDone?.Invoke(this, 1);
            Destroy(this.gameObject);
            yield return null;
    }
}

