using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenCollider : MonoBehaviour
{
    public GameObject spawnLocation;
    public GameObject carbonBox;
    private GameObject spawnedBox;

    public bool carbonPlaced = false;
    private void Start()
    {
        SpawnCarbonBox();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PickUp")
        {
            Destroy(spawnedBox);
            carbonPlaced = true;
        }
    }
    public void ResetOven()
    {
        if (spawnedBox != null)
        {
            Destroy(spawnedBox);
        }
        SpawnCarbonBox();
        carbonPlaced = false;
    }
    private void SpawnCarbonBox()
    {
        spawnedBox = Instantiate(carbonBox, spawnLocation.transform.position, Quaternion.identity,gameObject.transform.parent.transform.parent);
    }
}
