using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] obstacles;
    [SerializeField]
    private GameObject ColorChanger;
    [SerializeField]
    private GameObject Bonus;
    [SerializeField]
    private GameObject Fl;
    private GameObject prev;
    public float y = 2f;
    public float gap = 7f;
    private int count = 0;
    public int number_of_obstacles=0;
    void Start()
    {
        y = 2f;
        gap = 7f;
        Spawn(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(bool flag=false)
    {
        if(!flag)
        Destroy(prev);
        else
            flag = false;

        if (count == number_of_obstacles)
        {
            Instantiate(Fl, new Vector3(0, y, 0), Quaternion.identity);
        }
        else
        {
            int ri = Random.Range(0, obstacles.Length);
            prev = Instantiate(obstacles[ri], new Vector3(0, y, 0), Quaternion.identity);
            y = y + gap;
            Instantiate(ColorChanger, new Vector3(0, y, 0), Quaternion.identity);
            y = y + 2;
            Instantiate(Bonus, new Vector3(0, y, 0), Quaternion.identity);
            y = y + gap;
            count++;
        }
    }
}
