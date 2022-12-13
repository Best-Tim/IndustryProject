using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZincScale : MonoBehaviour
{
    public int scale;
    public int currentCottonCount;
    public List<GameObject> currentCottons = new List<GameObject>();
    

    public GameObject explosionVX;
    public GameObject waterEffect;

    public Transform liquidTransform;
    
    public Transform handlePos;
    
    private PlayerPickUpController pickUpController;

    public bool isStiring;
    private float stiringCounter;
    
    public float changeColorRate = 3;
    public Color color1, color2, color3;
    private List<Color> colors;
    public String currentColor;
    [SerializeField] private Material changableMaterial;

    [SerializeField] private GameObject liquidCircle;
    [SerializeField] private GameObject liquidFill;

    

    private void Awake()
    {
        pickUpController = FindObjectOfType<PlayerPickUpController>();
        isStiring = false;
        currentColor = "NEUTRAL";
        colors = new List<Color>();
        colors.Add(color1);
        colors.Add(color2);
        colors.Add(color3);
    }

    private void Update()
    {
        if (isStiring)
        {
            stiringCounter += Time.deltaTime;
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
        
        Material currentMaterial = liquidFill.GetComponent<MeshRenderer>().material;
        currentMaterial = changableMaterial;
        currentMaterial.color = colors[random];
        liquidFill.GetComponent<MeshRenderer>().material = currentMaterial;
        
        liquidCircle.GetComponent<SpriteRenderer>().color = colors[random];
        if (colors[random] == color1)
        {
            currentColor = "RED";
        }
        else if (colors[random] == color2)
        {
            currentColor = "GREEN";
        }
        else if (colors[random] == color3)
        {
            currentColor = "BLUE";
        }
        Instantiate(waterEffect, liquidTransform.position, waterEffect.transform.rotation);
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
                Instantiate(waterEffect, liquidTransform.position, waterEffect.transform.rotation);
                Destroy(other.gameObject);
            }
            else 
            {
                Destroy(other.gameObject);
                Explode();
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

    public void Explode()
    {
        Instantiate(explosionVX, gameObject.transform.position + new Vector3(0, .5f, 0), Quaternion.identity);
    }
}
