using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string scenename;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(scenename);
    }

}
