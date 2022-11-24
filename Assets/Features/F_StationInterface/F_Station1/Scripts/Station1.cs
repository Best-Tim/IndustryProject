using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Station1 : StationInterface
{
    public List<GameObject> Cottons = new List<GameObject>();
    public GameObject zincBowl;

    public ZincScale currentZinc;
    public List<GameObject> currentCottons;

    public GameObject cottonParent;
    public Transform zincLocation;

    private int rightAnswer = 0;
    private void Start()
    {
       SpawnObjects();
       FindRightAnswer();
    }
    void FixedUpdate()
    {
        WinCondition();
    }
    public override void reset()
    {
        for (int i = 0; i < currentCottons.Count; i++)
        {
            for (int j = 0; j < currentCottons[i].GetComponent<CottonPrefabController>().materials.Count; j++)
            {
                Destroy(currentCottons[i].GetComponent<CottonPrefabController>().materials[j]);
            }
            Destroy(currentCottons[i]);
        }
        Destroy(currentZinc.gameObject);
        SpawnObjects();
    }
    void SpawnObjects()
    {
        currentCottons = new List<GameObject>();
        // currentZinc = new GameObject();
        foreach (Transform t in cottonParent.transform.GetComponentInChildren<Transform>())
        {
            int i = Random.Range(0, Cottons.Count);
            GameObject g = Instantiate(Cottons[i], t.position, Quaternion.identity, gameObject.transform.parent); 
            Cottons.RemoveAt(i);
            currentCottons.Add(g);
        }
        GameObject zinc = Instantiate(zincBowl, zincLocation.position, Quaternion.identity, gameObject.transform.parent);
        currentZinc = zinc.GetComponent<ZincScale>();
    }
    void FindRightAnswer()
    {
        CottonPrefabController toBeChecked = null;
        foreach (var item in currentCottons)
        {
            if (item.GetComponent<CottonPrefabController>().Material == MATERIALS.COTTON)
            {
                toBeChecked = item.GetComponent<CottonPrefabController>();
            }
        }
        if (toBeChecked != null)
        {
            rightAnswer = CottonSwitch(toBeChecked.numberOfMaterials, currentZinc.scale);
        }
        if (rightAnswer == 0)
        {
            Debug.LogError("i dont know but something bad happened");
            return;
        }
    }
    void WinCondition()
    {
        if (currentZinc.currentCottonCount == rightAnswer)
        {
            completeStation();
        }
    }
    int CottonSwitch(int i, int scale)
    {
        switch (i, scale)
        {
            case (1,1):
                return 1;
            case (2,1):
                return 1;
            case (3,1):
                return 2;
            case (4,1):
                return 3;

            case (1, 2):
                return 1;
            case (2, 2):
                return 2;
            case (3, 2):
                return 3;
            case (4, 2):
                return 4;
        }
        return 0;
    }

}
