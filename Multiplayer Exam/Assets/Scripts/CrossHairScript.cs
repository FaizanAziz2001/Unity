using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairScript : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    Ray ray;
    RaycastHit rayInfo;

    private void Start()
    {
       
    }

    private void Update()
    {
        ray.origin = mainCam.transform.position;
        ray.direction = mainCam.transform.forward;
        if(!Physics.Raycast(ray, out rayInfo))
        {
            transform.position = ray.origin + ray.direction * 1000.0f;
        }
        else
            transform.position = rayInfo.point;

    }
}
