using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZincScale : MonoBehaviour
{
    public int scale;
    public int currentCottonCount;
    public List<GameObject> currentCottons = new List<GameObject>();
    

    public GameObject explosionVX;
    
    public Transform handlePos;
    
    private PlayerPickUpController pickUpController;

    public bool isStiring;
    private float stiringCounter;
    
    public float changeColorRate = 3;
    public Color color1, color2, color3, color4;
    private List<Color> colors;
    

    private void Awake()
    {
        pickUpController = FindObjectOfType<PlayerPickUpController>();
        isStiring = false;
        colors = new List<Color>();
        colors.Add(color1);
        colors.Add(color2);
        colors.Add(color3);
        colors.Add(color4);
    }

    private void Update()
    {
        if (isStiring)
        {
            stiringCounter += Time.deltaTime;
            Debug.Log(stiringCounter);
            if (stiringCounter >= changeColorRate)
            {
                RandomizedColor();
                stiringCounter = 0;
            }
        }
    }

    public void RandomizedColor()
    {
        int random = Random.Range(0, colors.Count);
        foreach (var cotton in currentCottons)
        {
            cotton.GetComponent<MeshRenderer>().material.color = colors[random];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp") && other.gameObject.TryGetComponent(out Identifier identifier))
        {
            other.gameObject.tag = "Untagged";
            if (identifier.materials == MATERIALS.COTTON)
            {
                currentCottonCount++;
                currentCottons.Add(other.gameObject);
            }
            else 
            {
                Destroy(other.gameObject);
                Instantiate(explosionVX, gameObject.transform.position + new Vector3(0,.5f,0), Quaternion.identity);
            }
        }
        else if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.tag = "Rotatable";
            pickUpController.DropObject();
            pickUpController.rotateObject = other.gameObject;
            other.gameObject.transform.position = handlePos.position;
            other.gameObject.transform.rotation = handlePos.rotation;
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.useGravity = false;
        }
    }
}
