using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottomscripts : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bananas" || target.tag == "OneBanana"
             || target.tag == "Platform" || target.tag == "Background"
             || target.tag == "Bird")
        {
            target.gameObject.SetActive(false);
        }
    }
}
