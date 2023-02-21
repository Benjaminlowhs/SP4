using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventorybutton : MonoBehaviour
{
    public static InventoryButton Instance;

    public GameObject Inventory;
    public GameObject List;
    public bool opened;

    private void Start()
    {
        Inventory.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!opened)
            {
                Ion();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Ioff();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void Ion()
    {
        Inventory.SetActive(true);
        opened = true;
        List.GetComponent<InventoryManager>().ListItems();

    }
    public void Ioff()
    {
        Inventory.SetActive(false);
        opened = false;
        InventoryManager.Instance.CleanItems();
        //List.GetComponent<InventoryManager>().ListItems();

    }
}
