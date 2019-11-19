using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject GameOverText;
    public bool gameover = false;
    public float scrollspeed = -1.5f;
    private float score = 0f;
    public Text scoretext;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdDied()
    {
        gameover = true;
        GameOverText.SetActive(true);
    }

    public void BirdScored()
    {
        if (gameover)
        {
            return;
        }
        score++;
        scoretext.text = "Score: " + score.ToString();
    }
}
