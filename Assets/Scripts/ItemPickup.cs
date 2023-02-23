using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    public Item Item;
    Camera fpsCamera;
    bool inrange = false;

    //public GameObject panel;

    public void Start()
    {
        if (fpsCamera == null)
            fpsCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
    }
    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Debug.Log("AAAAAAAAAAAA");
        Destroy(gameObject);
        //panel.SetActive(false);

    }

    private void OnMouseDown()
    {
        Pickup();
        Debug.Log("Picked up");
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("in " + other);
    //    if (other.gameObject.tag == "Player")
    //    {
    //        panel.SetActive(true);
    //        Debug.Log("Do something else here");
    //        inrange = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    panel.SetActive(false);
    //    Debug.Log("out " + other);
    //    inrange = false;

    //}

    //private void Update()
    //{
    //    if(inrange==true)
    //    {
    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            Pickup();
    //        }
    //    }
        
    //}

	public void Interact(Transform interactorTransform)
	{
        Pickup();
	}

	public string GetInteractText()
	{
        return "Press 'E' to Pick Up "+ Item.itemName;
	}

	public Transform GetTransform()
	{
        return transform;
	}
}
