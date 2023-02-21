using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lose2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Lose2");
        SceneManager.LoadScene("Lose2");

    }
}
