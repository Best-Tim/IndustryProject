using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station1 : StationInterface
{
    public List<GameObject> Cottons = new List<GameObject>();
    public List<GameObject> Zincs = new List<GameObject> ();

    public GameObject cottonParent;
    public Transform zincLocation;

    private void Start()
    {
        foreach (Transform t in cottonParent.transform.GetComponentInChildren<Transform>())
        {
            GameObject g = Cottons[Random.Range(0, Cottons.Count)];
            Instantiate(g, t.position, Quaternion.identity, gameObject.transform.parent);
            Cottons.Remove(g);
        }
        Instantiate(Zincs[Random.Range(0, Zincs.Count)], zincLocation.position, Quaternion.identity, gameObject.transform.parent);
    }
    void Logic()
    {

    }
}
