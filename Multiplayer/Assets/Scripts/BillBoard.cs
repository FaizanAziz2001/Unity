using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    [SerializeField] Camera cam;
    // Update is called once per frame
    void Update()
    {
      
        transform.LookAt(cam.transform);
        transform.Rotate(Vector3.up * 0);

    }
}
