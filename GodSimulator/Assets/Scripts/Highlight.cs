using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{


    public Transform human;

    // Update is called once per frame
    void Update()
    {
        if (transform.gameObject.activeSelf == true)
        {
            Vector3 tmp = human.position;
            tmp.y += 10;
            transform.position = tmp;
        }
    }
}