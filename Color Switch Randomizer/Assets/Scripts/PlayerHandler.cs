using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public int JumpFact = 0;
    public Rigidbody2D rb;
    public SpriteRenderer Sr;
    public AudioSource ar,cc;
    public Level1_Controller LC;
    public Color pink, yellow, purple, cyan;
    string Playercolor;
    int score;

    void Start()
    {
        SetColor();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
   
        if (Input.GetMouseButton(0) || Input.GetButton("Jump"))
            rb.velocity = Vector2.up * JumpFact;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.tag=="Finish")
        {
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene("MainMenu");
        }
        else if (collision.tag == "Bonus")
        {
            
            score++;
            Display_Score.sco = score;
            ar.Play();
            Debug.Log("score:" + score);
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "ColourCircle")
        {
            SetColor();
            cc.Play();
            LC.Spawn();
            Destroy(collision.gameObject);
           
        }
        else if (collision.tag != Playercolor)
        {

            Debug.Log("score:" + score);
            score = 0;
            Display_Score.sco = score;
            SceneManager.LoadScene("Level 1");
        }
    }
    void SetColor()
    {
        int col = Random.Range(1, 5);
        switch (col)
        {
            case 1:
                Sr.color = pink;
                Playercolor = "Pink";
                break;
            case 2:
                Sr.color = yellow;
                Playercolor = "Yellow";
                break;
            case 3:
                Sr.color = purple;
                Playercolor = "Purple";
                break;
            case 4:
                Sr.color = cyan;
                Playercolor = "Cyan";
                break;
            case 5:
                Sr.color = cyan;
                Playercolor = "Cyan";
                break;

        }
    }
}
