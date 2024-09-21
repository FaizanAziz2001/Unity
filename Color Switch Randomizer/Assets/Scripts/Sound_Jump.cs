using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Jump : MonoBehaviour
{
    public AudioSource ar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playSound();
    }

    void playSound()
    {
        
        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump"))
        {
      
            ar.Play();
        }
    }
}
