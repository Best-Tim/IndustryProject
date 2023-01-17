using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<StationInterface> stations;

    private void Start()
    {
        stations.AddRange(FindObjectsOfType<StationInterface>());
        SingletonUI.Instance.SetNewGeraldUI("Welcome to the factory newbies! Today you and your collegue will learn how to build a lightbulb!", 5);
    }

}
