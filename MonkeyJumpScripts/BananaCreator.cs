using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject onebanana, threebananas;

    [SerializeField]
    private Transform point;
    private GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 10) > 3)
        {
            temp = Instantiate(onebanana, point.position, Quaternion.identity);
        }
        else
        {
            temp = Instantiate(threebananas, point.position, Quaternion.identity);
        }
        temp.transform.parent = SpawnerController.instance.platformsaver;
    }

}
