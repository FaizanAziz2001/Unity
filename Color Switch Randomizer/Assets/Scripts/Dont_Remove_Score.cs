using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Remove_Score : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("score");
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);

    }
}
