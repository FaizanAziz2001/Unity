using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject Bonus;
    [SerializeField]
    int number_of_obstacles;
    private GameObject prev;
    public float y = 2f;
    public float gap = 3f;
    private int count = 0;
    void Start()
    {
        Spawn(true);
    }

    public void Spawn(bool flag = false)
    {
        if (!flag)
            Destroy(prev);
        else
            flag = false;


        if (count >= number_of_obstacles)
        {
            return;
        }
        {
            Instantiate(Bonus, new Vector3(0, y, 0), Quaternion.identity);
            gap = Random.Range(2f, 6f);
            y = y + gap;
            count++;
        }
    }
}
