using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Win2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("win2");
        SceneManager.LoadScene("Win2");

    }

    
}
