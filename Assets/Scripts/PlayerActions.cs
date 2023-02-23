using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GameObject assaultRifle, handgun;
    public GameObject grenade;

    InventoryManager inventoryManager;
    bool hasAssaultRifle;
    Camera m_camera;

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

    void ThrowGrenade()
    {
        GameObject grenadeInstance = Instantiate(grenade, m_camera.transform.position + m_camera.transform.forward * 0.5f, gameObject.transform.rotation);
        Vector3 throwForce = m_camera.transform.forward * 3f + transform.up * 0.5f;
        grenadeInstance.GetComponent<Rigidbody>().AddForce(throwForce, ForceMode.Impulse);
    }

    void Start()
    {
        inventoryManager = InventoryManager.Instance;

        m_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        // hasAssaultRifle = CheckAssaultRifle();

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

        if (Input.GetKeyDown(KeyCode.G))
        {
            ThrowGrenade();
        }
    }
}
