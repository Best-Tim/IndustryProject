using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    public List<Transform> transformList = new List<Transform>();
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void MakeRed()
    {
        anim.SetBool("Red", true);
        StartCoroutine(Waitfor(1));
    }
    private IEnumerator Waitfor(int s)
    {
        yield return new WaitForSecondsRealtime(s);
        anim.SetBool("Red", false);
    }
    public void MakeGreen()
    {
        foreach(Transform t in transformList)
        {
            t.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}
