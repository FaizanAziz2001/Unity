using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    public SpriteRenderer Sr;
    Color32 pink = new Color32(255, 1, 129,255);
    Color32 purple = new Color32(138, 43, 226,255);
    Color32 yellow = new Color32(244, 223, 16,255);
    Color32 cyan = new Color32(54, 226, 244,255);

    void Start()
    {
        SetColour();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void SetColour()
    {
        int col = Random.Range(1, 5);
        switch (col)
        {
            case 1:
                Sr.color = pink;
                break;
            case 2:
                Sr.color = yellow;
                break;
            case 3:
                Sr.color = purple;
                break;
            case 4:
                Sr.color = cyan;
                break;
        }
    }
}
