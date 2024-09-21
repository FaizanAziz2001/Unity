using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource ar;
    int score;
    void Start()
    {
        score = Display_Score.sco;
        ar.Play();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
