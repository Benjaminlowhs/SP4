using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rifleUI;
    public GameObject pistolUI;
    public GameObject assaultRifle;
    public GameObject pistol;

    // Update is called once per frame
    void Update()
    {
        pistolUI.SetActive(pistol.activeSelf);
        
        rifleUI.SetActive(assaultRifle.activeSelf);
       
    }
}
