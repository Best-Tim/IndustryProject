using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    public List<Transform> transformList = new List<Transform>();
    public void MakeGreen()
    {
        foreach(Transform t in transformList)
        {
            t.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}
