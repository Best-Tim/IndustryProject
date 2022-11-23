using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station1 : StationInterface
{
    public List<GameObject> Cottons = new List<GameObject>();
    public List<GameObject> Zincs = new List<GameObject> ();

    public GameObject currentZinc;
    public List<GameObject> currentCottons;

    public GameObject cottonParent;
    public Transform zincLocation;

    private void Start()
    {
       SpawnObjects();
    }

    public override void reset()
    {
        for (int i = 0; i < currentCottons.Count; i++)
        {
            Destroy(currentCottons[i]);
        }
        Destroy(currentZinc);
        SpawnObjects();
    }

    void SpawnObjects()
    {
        currentCottons = new List<GameObject>();
        currentZinc = new GameObject();
        foreach (Transform t in cottonParent.transform.GetComponentInChildren<Transform>())
        {
            GameObject g = Instantiate(Cottons[Random.Range(0, Cottons.Count)], t.position, Quaternion.identity, gameObject.transform.parent);
            Cottons.Remove(g);
            currentCottons.Add(g);
        }
        GameObject zinc = Instantiate(Zincs[Random.Range(0, Zincs.Count)], zincLocation.position, Quaternion.identity, gameObject.transform.parent);
        currentZinc = zinc;
    }
    void Logic()
    {
        
    }
}
