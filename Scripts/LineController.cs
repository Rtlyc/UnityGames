using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public GameObject linePrefab;
    public Transform lineparent;
    public GameObject eraser;
    private bool iserased;

    Line CurrentLine;

    public Material redcolor, blackcolor, bluecolor, pinkcolor, greencolor, yellowcolor;

    private void Update()
    {
        if (iserased)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Erase");
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                eraser.transform.position = pos;
            }
        }
        if (!iserased)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (pos.x < 0)
                {
                    return;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                GameObject LineGo = Instantiate(linePrefab);
                CurrentLine = LineGo.GetComponent<Line>();
                LineGo.gameObject.transform.parent = lineparent;
            }

            if (Input.GetMouseButtonUp(0))
            {
                CurrentLine = null;
            }

            if (CurrentLine != null)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                CurrentLine.UpdateLine(pos);
            }
        }

    }

    public void erase()
    {
        iserased = true;
    }

    public void Change_to_red()
    {
        iserased = false;
        LineRenderer renderer = linePrefab.GetComponent<LineRenderer>();
        renderer.material = redcolor;
    }

    public void Change_to_blue()
    {
        iserased = false;
        LineRenderer renderer = linePrefab.GetComponent<LineRenderer>();
        renderer.material = bluecolor;
    }

    public void Change_to_black()
    {
        iserased = false;
        LineRenderer renderer = linePrefab.GetComponent<LineRenderer>();
        renderer.material = blackcolor;
    }


    public void Change_to_green()
    {
        iserased = false;
        LineRenderer renderer = linePrefab.GetComponent<LineRenderer>();
        renderer.material = greencolor;
    }


    public void Change_to_pink()
    {
        iserased = false;
        LineRenderer renderer = linePrefab.GetComponent<LineRenderer>();
        renderer.material = pinkcolor;
    }

    public void Change_to_yellow()
    {
        iserased = false;
        LineRenderer renderer = linePrefab.GetComponent<LineRenderer>();
        renderer.material = yellowcolor;
    }

    public void Change_pensize(float num)
    {
        iserased = false;
        LineRenderer renderer = linePrefab.GetComponent<LineRenderer>();
        renderer.startWidth = num/10;
    }
}
