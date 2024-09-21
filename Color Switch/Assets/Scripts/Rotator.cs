using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Transform Tr;
    public int Direction=1;
    public int Rotation=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Tr.Rotate(0f,0f,Direction*Rotation*Time.deltaTime);
    }
}
