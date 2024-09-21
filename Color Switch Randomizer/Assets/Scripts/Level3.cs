using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour
{
    int score,counter=0;
    public float JumpFact=3;
    public int coln = 1;
    public Rigidbody2D rb;
    string Playercolor;
    public SpriteRenderer Sr;
    public Transform ball;
    public AudioSource cc;
    public Color pink, yellow, purple, cyan;
    string[] ar=new string[4];
    int index;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score");
        SetColor();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetButton("Jump"))
            rb.velocity = Vector2.up * JumpFact;
        if(ball.position.y<-5)
            SceneManager.LoadScene("Level 3");
        else if(ball.position.y> 5)
            SceneManager.LoadScene("Level 3");
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == Playercolor)
        {
            if(counter%2==0)
                ar[index++] = Playercolor;
            score++;
            Display_Score.sco = score;
            counter++;
            cc.Play();
            Debug.Log(score);
            Destroy(collision.gameObject);
            if (counter >= 8)
            {

                PlayerPrefs.SetInt("score", score);
                SceneManager.LoadScene("MainMenu");
            }
        }
        else if (collision.tag == "ColourCircle")
        {
            Debug.Log(collision.tag);
            cc.Play();
            for (int i=0;i<4;i++)
            {
                
                if (Playercolor == ar[i])
                    SetColor();
            }
            
            
        }
        else
            SceneManager.LoadScene("Level 3");
  
    }

    void SetColor()
    {
      
            int col = Random.Range(1, 5);
        
   
      
        switch (col)
        {
            case 1:
                Sr.color = pink;
                Playercolor = "Pink";
                coln = col;
                break;
            case 2:
                Sr.color = yellow;
                Playercolor = "Yellow";
                coln = col;
                break;
            case 3:
                Sr.color = purple;
                Playercolor = "Purple";
                coln = col;
                break;
            case 4:
                Sr.color = cyan;
                Playercolor = "Cyan";
                coln = col;
                break;

        }
    }
    
}
