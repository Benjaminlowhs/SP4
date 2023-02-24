using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeControl : MonoBehaviour
{
    Fade fader;
    // Start is called before the first frame update
    void Start()
    {
        fader = FindObjectOfType<Fade>();
        fader.FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
