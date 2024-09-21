using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveleft : MonoBehaviour
{
    public int speed=3;
    public float boundry = -3f;
    public float opposite_boundry=6f;
    private Vector3 dir = Vector3.left;
    public Transform Tr;
    //Your Update function
    void Update()
    {
        Tr.Translate(dir * speed * Time.deltaTime);

        if (transform.position.x <= boundry)
        {
            Tr.position=new Vector2(Tr.position.x+opposite_boundry,Tr.position.y);
        }
    
    }
}
