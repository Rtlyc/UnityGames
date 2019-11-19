using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperScripts : MonoBehaviour
{
    private GameObject[] bg;
    private float height, max_height;
    void Awake()
    {
        bg = GameObject.FindGameObjectsWithTag("Background");
    }
    // Start is called before the first frame update
    void Start()
    {
        height = bg[0].GetComponent<BoxCollider2D>().bounds.size.y;

        max_height = bg[0].transform.position.y;
        for (int i = 0; i < bg.Length; i++)
        {
            if(bg[i].transform.position.y > max_height)
            {
                max_height = bg[i].transform.position.y;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Background")
        {
            if(target.transform.position.y >= max_height)
            {
                Vector2 temp = transform.position;
                for (int i = 0; i < bg.Length; i++)
                {
                    if (!bg[i].activeInHierarchy)
                    {
                        temp.y += height;
                        bg[i].transform.position = temp;
                        bg[i].gameObject.SetActive(true);
                        max_height = temp.y;
                    }
                }
            }
        }
    }
}
