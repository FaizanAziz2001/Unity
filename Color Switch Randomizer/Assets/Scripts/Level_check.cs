using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_check : MonoBehaviour
{
    
   

    public void SaveLevel(int id)
    {
    PlayerPrefs.SetInt("level",id);
    }

    
}
