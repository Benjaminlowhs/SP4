using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    InventoryManager inventoryManager;
    [SerializeField]
    bool hasAssaultRifle;

    public GameObject assaultRifle, handgun;

    bool CheckAssaultRifle()
    {
        if (hasAssaultRifle)
            return true;

        for (int i = 0; i < inventoryManager.Items.Count; ++i)
        {
            if (inventoryManager.Items[i].itemName == "Rifle")
                return true;
        }

        return false;
    }

    void Start()
    {
        inventoryManager = InventoryManager.Instance;
    }

    void Update()
    {
        hasAssaultRifle = CheckAssaultRifle();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (hasAssaultRifle)
                assaultRifle.SetActive(false);
            handgun.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (hasAssaultRifle)
            {
                assaultRifle.SetActive(true);
                handgun.SetActive(false);
            }
        }
    }
}
