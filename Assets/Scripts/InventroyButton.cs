using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public static InventoryButton Instance;

    public GameObject Inventory;

    public bool opened;

    private void Start()
    {
        Inventory.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(!opened)
            {
                Ion();            
            }
            else
            {
                Ioff();
            }
        }
    }

    public void Ion()
    {
        Inventory.SetActive(true);
        opened = true;
    }
    public void Ioff()
    {
        Inventory.SetActive(false);
        opened = false;
    }
}
