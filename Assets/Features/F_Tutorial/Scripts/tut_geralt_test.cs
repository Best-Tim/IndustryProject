using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_geralt_test : MonoBehaviour
{
    private int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            
            SingletonUI.Instance.SetNewGeraldUI(count.ToString());
            count++;
            SingletonUI.Instance.SetNewGeraldUI(count.ToString());
            count++;
            SingletonUI.Instance.SetNewGeraldUI(count.ToString());
            count++;
            SingletonUI.Instance.SetNewGeraldUI(count.ToString());
            count++;
        }
    }
}
