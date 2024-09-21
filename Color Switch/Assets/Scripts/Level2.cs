using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int JumpFact = 0;
    public Rigidbody2D rb;
    public SpriteRenderer Sr;
    public AudioSource ar, cc;
    public Color pink, yellow, purple, cyan;
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
        if (Input.GetMouseButton(0) || Input.GetButton("Jump"))
            rb.velocity = Vector2.up * JumpFact;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Finish")
        {
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene("Level 3");
            //SceneManager.LoadScene("Game Over");
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
            cc.Play();
            SetColor();
            Destroy(collision.gameObject);
        }
        else if (collision.tag != Playercolor)
        {

            Debug.Log("score:" + score);
            SceneManager.LoadScene("Level 2");
            score = 0;
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
