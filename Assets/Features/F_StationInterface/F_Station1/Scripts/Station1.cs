using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Station1 : StationInterface
{
    public List<GameObject> Materials = new List<GameObject>();
    public List<GameObject> zincBowls;

    public ZincScale currentZinc;
    public List<GameObject> currentMaterials;

    public GameObject cottonParent;
    public Transform zincLocation;

    private int rightAnswer = 0;

    public CheckWinCondition button;
    private Color colorToWin;
    private void Start()
    {
       SpawnObjects();
       FindRightAnswer();
    }
    void FixedUpdate()
    {
        if (button.isPressed)
        {
            WinCondition();
            button.isPressed = false;
        }
    }
    public override void reset()
    {
        for (int i = 0; i < currentMaterials.Count; i++)
        {
            for (int j = 0; j < currentMaterials[i].GetComponent<CottonPrefabController>().materials.Count; j++)
            {
                Destroy(currentMaterials[i].GetComponent<CottonPrefabController>().materials[j]);
            }
            Destroy(currentMaterials[i]);
        }
        Destroy(currentZinc.gameObject);
        SpawnObjects();
    }
    void SpawnObjects()
    {
        currentMaterials = new List<GameObject>();
        // currentZinc = new GameObject();
        foreach (Transform t in cottonParent.transform.GetComponentInChildren<Transform>())
        {
            int i = Random.Range(0, Materials.Count);
            GameObject g = Instantiate(Materials[i], t.position, Quaternion.identity, gameObject.transform.parent); 
            Materials.RemoveAt(i);
            currentMaterials.Add(g);
        }
        GameObject zinc = Instantiate(zincBowls[Random.Range(0,zincBowls.Count)], zincLocation.position, Quaternion.identity, gameObject.transform.parent);
        currentZinc = zinc.GetComponent<ZincScale>();
    }
    void FindRightAnswer()
    {
        CottonPrefabController toBeChecked = null;
        foreach (var item in currentMaterials)
        {
            if (item.GetComponent<CottonPrefabController>().Material == MATERIALS.COTTON)
            {
                toBeChecked = item.GetComponent<CottonPrefabController>();
            }
        }
        if (toBeChecked != null)
        {
            rightAnswer = CottonSwitch(currentZinc.scale);
        }
        if (rightAnswer == 0)
        {
            Debug.LogError("i dont know but something bad happened");
            return;
        }
    }
    public override void WinCondition()
    {
        if (currentZinc.currentCottonCount == rightAnswer)
        {
            if (rightAnswer == 3 && currentZinc.currentColor == Color.red)
            {
                completeStation();
                Debug.Log("I won R");

            }
            if (rightAnswer == 4 && currentZinc.currentColor == Color.blue)
            {
                completeStation();
                Debug.Log("I won B");

            }
            if (rightAnswer == 5 && currentZinc.currentColor == Color.green)
            {
                completeStation();
                Debug.Log("I won G");
            }
        }
    }
    int CottonSwitch(int scale)
    {
        switch (scale)
        {
            case (1):
                return 3;
            case (2):
                return 4;
            case (3):
                return 5;
        }
        return 6;
    }

}
