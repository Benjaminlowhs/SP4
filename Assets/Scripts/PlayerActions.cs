using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerActions : MonoBehaviour
{
    public GameObject assaultRifle, handgun;
    public GameObject grenade;
    public GameObject HeliW, HeliL, Door;
    public TMP_Text GrenadeCounter;
    InventoryManager inventoryManager;
    bool hasAssaultRifle;
    Camera m_camera;

    int grenadeCount = 3;

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
        HeliL.SetActive(false);
        HeliW.SetActive(false);
        Door.SetActive(true);

    }

    public bool EndGame()
    {
        for (int i = 0; i < inventoryManager.Items.Count; ++i)
        {
            if (inventoryManager.Items[i].itemName == "Cure A")
            {
                Door.SetActive(false);
                HeliW.SetActive(true);
                Debug.Log("EndingW");
                return false;

            }
            else if(inventoryManager.Items[i].itemName == "Cure B")
            {
                Door.SetActive(false);
                HeliL.SetActive(true);
                Debug.Log("EndingL");
                return false;
            }
            else
            {
                continue;
                    
            }
        }
        return true;

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

        if (Input.GetKeyDown(KeyCode.G) && grenadeCount > 0)
        {
            ThrowGrenade();
            grenadeCount--;
        }

        if(EndGame()==true)
        {
            EndGame();
        }

        if (grenadeCount >= 0)
        {
            GrenadeCounter.text = grenadeCount.ToString();
        }
    }
}
