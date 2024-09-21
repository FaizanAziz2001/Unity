using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public int speed = 3;
    public float boundry = 3f;
    public float opposite_boundry = -3f;
    private Vector3 dir = Vector3.right;
    public Transform Tr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    //Your Update function
    void Update()
    {
        Tr.Translate(dir * speed * Time.deltaTime);
        if (transform.position.x >= boundry)
        {
            dir = -dir;
        }
        else if(transform.position.x <= opposite_boundry)
        {
            dir = -dir;
        }

    }
}
