using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    public List<Transform> transformList = new List<Transform>();

    public void MakeRed()
    {
        foreach (Transform t in transformList)
        {
            t.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
    private IEnumerator Waitfor(int s)
    {
        yield return new WaitForSecondsRealtime(s);
    }
    public void MakeGreen()
    {
        foreach(Transform t in transformList)
        {
            t.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}
