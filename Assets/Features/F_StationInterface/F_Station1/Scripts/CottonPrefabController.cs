using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CottonPrefabController : MonoBehaviour
{
    public GameObject matToSpawn;
    public int numberOfMaterials;
    public MATERIALS Material;
    public List<GameObject> materials;

    private void Awake()
    {
        if (Material != MATERIALS.COTTON)
        {
            numberOfMaterials = UnityEngine.Random.Range(1,4);
            for (int i = 0; i < numberOfMaterials; i++)
            {
                GameObject g = Instantiate(matToSpawn, gameObject.transform.position + new Vector3(0, .2f, 0), Quaternion.identity, this.transform);
                materials.Add(g);
                Material = g.GetComponent<Identifier>().materials;
            }
        }
        else
        {
            // numberOfMaterials = 5;
            // for (int i = 0; i < numberOfMaterials; i++)
            // {
            //     GameObject g = Instantiate(matToSpawn, gameObject.transform.position + new Vector3(0, .2f, 0), Quaternion.identity, this.transform);
            //     materials.Add(g);
            //     Material = g.GetComponent<Identifier>().materials;
            // }
        }
    }
}
