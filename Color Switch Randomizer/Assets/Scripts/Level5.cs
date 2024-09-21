using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform Tr;
    public Transform CameraPos;
    public Transform PlayerPos;
    public AudioSource ar, cc;
    public int dir = 1;
    public int JumpFact = 3;
    public Color pink, yellow, purple, cyan;
    public Level5_Controller LC;
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
        if (Input.GetMouseButton(0) || Input.GetButton("Jump"))
            rb.velocity = Vector2.up * JumpFact;
        if (PlayerPos.position.y < CameraPos.position.y)
        {
            CameraPos.position = new Vector3(CameraPos.position.x, PlayerPos.position.y, CameraPos.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Finish")
        {
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene("Game Over");
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
            LC.Spawn();
            Destroy(collision.gameObject);
        }
        else if (collision.tag != Playercolor)
        {

            Debug.Log("score:" + score);
            SceneManager.LoadScene("Level 5");
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
