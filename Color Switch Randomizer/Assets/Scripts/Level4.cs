using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform Tr;
    public AudioSource ar;
    public int dir=1;
    public int JumpFact = 3;
    float rboundry = 3f;
    float lboundry = -3f;
    public Color pink, yellow, purple, cyan;
    public Level4_Controller LC;

    public SpriteRenderer Sr;
    string Playercolor;
    int score;
    void Start()
    {
        SetColor();
        score = PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    void Update()
    {

        if (Tr.position.x > rboundry)
            SceneManager.LoadScene("Level 4");
        else if (Tr.position.x < lboundry)
            SceneManager.LoadScene("Level 4");

        if (Input.GetMouseButton(0) || Input.GetButton("Jump"))
        {
            rb.velocity = Vector2.one * new Vector2(dir * 2* JumpFact, JumpFact*1.8f);

            
            if (Tr.position.x <= lboundry+0.7)
                dir = 1;
            else if(Tr.position.x>=rboundry-0.7)
                dir = -1;
        }

       if(Tr.position.y<-5)
            SceneManager.LoadScene("Level 4");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Finish")
        {
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene("MainMenu");
        }
        else if (collision.tag == "Bonus")
        {
            score++;
            Display_Score.sco = score;
            LC.Spawn();
            ar.Play();
            Debug.Log("score:" + score);
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "ColourCircle")
        {
            SetColor();
            Destroy(collision.gameObject);
        }
        else if (collision.tag != Playercolor)
        {

            Debug.Log("score:" + score);
            SceneManager.LoadScene("Level 4");
            score = 0;
        }
        
    }

    void SetColor()
    {
        int col = Random.Range(1, 4);
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

        }
    }
}
