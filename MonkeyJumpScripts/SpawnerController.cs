using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public static SpawnerController instance;

    [SerializeField]
    private GameObject leftplatform, rightplatform, onebird;

    private float Left_X_Min = -4.4f, Left_X_Max = -2.8f, Right_X_Min = 4.4f, Right_X_Max = 2.8f;
    public float threshold = 4f;
    private int platformsize = 8;

    private float bird_y = 5f;

    private float bird_Min_x = -2.3f, bird_Max_x = 2.3f;

    private float y_loc;

    public Transform platformsaver = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        y_loc = transform.position.y;
        CreatePlatform();
    }

    public void CreatePlatform()
    {
        Vector2 temploc = transform.position;
        GameObject tempobject = null;

        float x_loc;
        for (int i = 0; i < platformsize; i++)
        {

            if (i%2 == 0)
            {
                x_loc = Random.Range(Left_X_Min, Left_X_Max);
                temploc.x = x_loc;
                temploc.y = y_loc;
                tempobject = Instantiate(rightplatform, temploc, Quaternion.identity);
            }
            else
            {
                x_loc = Random.Range(Right_X_Min, Right_X_Max);
                temploc.x = x_loc;
                temploc.y = y_loc;
                tempobject = Instantiate(leftplatform, temploc, Quaternion.identity);
            }
            tempobject.transform.parent = platformsaver;
            y_loc += threshold;

        }
        if(Random.Range(0,5)> 2)
        {
            CreateOneBird();
        }
    }

    private void CreateOneBird()
    {
        float x = Random.Range(bird_Min_x, bird_Max_x);
        Vector2 loc = transform.position;
        loc.x = x;
        loc.y += bird_y;
        GameObject temp = Instantiate(onebird, loc, Quaternion.identity);
        temp.transform.parent = platformsaver;
    }

}
