using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Display_Score : MonoBehaviour
{
    public Text s;
    public static int sco = 0;
    void Start()
    {
        s.text = "Score " + sco;
    }

    // Update is called once per frame
    void Update()
    {
        s.text = "Score " + sco;
    }
}
