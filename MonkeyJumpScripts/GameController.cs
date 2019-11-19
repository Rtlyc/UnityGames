using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]
    private Text scoretext,highesttext;
    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    void LoadGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void RestartGame()
    {
        Invoke("LoadGame", 2f);
    }

    public void Display(float k) {
        scoretext.text = "Score: " + k.ToString();
    }

    public void Display_History(float k) {
        highesttext.text = "Highest: " + k.ToString();
    }


}
