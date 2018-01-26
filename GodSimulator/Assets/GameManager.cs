using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject lightObj;
    public int time = 5;

    private int timeCounter = 0;
    private float angle;
    private void Start()
    {
        StartCoroutine("passTime");
    }
    private void Update()
    {
 
           // float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
           //lightObj.transform.eulerAngles = new Vector3( angle, 0, 0);

    }

    IEnumerator passTime()
    {
        
        yield return new WaitForSeconds(1/8f);
        timeCounter++;
        if (timeCounter == 80)
        {
            timeCounter = 0;
            time++;
        }
        if ( time > 23 )
        {
            time = 0;
            // enable pt light
        }
        else if ( time == 5 )
        {
            // disable pt light
        }
        else
        {
            Vector3 tmp = lightObj.transform.eulerAngles;
            tmp.x += timeCounter / 5;// * Time.deltaTime;
            lightObj.transform.eulerAngles = tmp;
        }
        StartCoroutine("passTime");

    }
}
