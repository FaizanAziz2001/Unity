using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   public AudioSource ar;
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ar.Play();
            PlayerPrefs.SetInt("level", 0);
            SceneManager.LoadScene("MainMenu");
        }
    }
   
}
