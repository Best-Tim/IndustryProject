using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Station1 : StationInterface
{
    public List<GameObject> Materials = new List<GameObject>();
    public List<GameObject> zincBowls;
    public List<GameObject> availableMaterials;

    public ZincScale currentZinc;
    public List<GameObject> currentMaterials;

    public GameObject cottonParent;
    public Transform zincLocation;

    private int rightAnswer = 0;

    public CheckWinCondition button;
    private Color colorToWin;

    private bool isFinished;

    public GameObject stirringHandlePrefab;
    public GameObject stirringHandleSpawnPos;
    private GameObject stirringHandle;

    private void Awake()
    {
        isFinished = false;
        SpawnObjects();
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
        currentZinc.Explode();
        Destroy(currentZinc.gameObject);
        Destroy(stirringHandle);
        SpawnObjects();
    }
    void SpawnObjects()
    {
        currentMaterials = new List<GameObject>();
        availableMaterials = new List<GameObject>();
        availableMaterials.AddRange(Materials);
        foreach (Transform t in cottonParent.transform.GetComponentInChildren<Transform>())
        {
            int i = Random.Range(0, availableMaterials.Count);
            GameObject g = Instantiate(availableMaterials[i], t.position, Quaternion.identity, gameObject.transform.parent); 
            availableMaterials.RemoveAt(i);
            currentMaterials.Add(g);
        }
        GameObject zinc = Instantiate(zincBowls[Random.Range(0,zincBowls.Count)], zincLocation.position, Quaternion.identity, gameObject.transform.parent);
        currentZinc = zinc.GetComponent<ZincScale>();
        stirringHandle = Instantiate(stirringHandlePrefab, stirringHandleSpawnPos.transform.position,
            stirringHandleSpawnPos.transform.rotation);
        FindRightAnswer();
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
        }
    }
    public override void WinCondition()
    {
        if (currentZinc.currentCottonCount == rightAnswer)
        {
            if (rightAnswer == 3 && currentZinc.currentColor == "RED")
            {
                completeStation();
                isFinished = true;

            }
            if (rightAnswer == 4 && currentZinc.currentColor == "BLUE")
            {
                completeStation();
                isFinished = true;

            }
            if (rightAnswer == 5 && currentZinc.currentColor == "GREEN")
            {
                completeStation();
                isFinished = true;
            }
        }
        else if (!isFinished)
        {
            reset();
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
