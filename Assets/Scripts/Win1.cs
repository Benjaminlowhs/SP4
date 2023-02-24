using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Win1 : MonoBehaviour
{
    Fade fader;
    private void Start()
    {
        fader = FindObjectOfType<Fade>();
    }

    public IEnumerator ChangeScene()
    {
        fader.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Win1");
    }

    private void OnTriggerEnter(Collider other)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("win1");
        StartCoroutine(ChangeScene());
    }

    
}
