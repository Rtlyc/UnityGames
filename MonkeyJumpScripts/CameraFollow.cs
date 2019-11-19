using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Transform target;
    private bool follow;
    public float threshold = -2.6f; 
    // Start is called before the first frame update
    void Awake()
    {
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if(target.position.y > (transform.position.y - threshold))
        {
            follow = true;
        }else if(target.position.y < transform.position.y)
        {
            follow = false;
        }

        if (follow)
        {
            Vector3 temp = transform.position;
            temp.y = target.position.y;
            transform.position = temp;
        }
    }
}
