using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{


   public Transform CameraPos;
    public Transform PlayerPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPos.position.y>CameraPos.position.y)
        {
            CameraPos.position = new Vector3(CameraPos.position.x,PlayerPos.position.y, CameraPos.position.z);
        }
    }
}
