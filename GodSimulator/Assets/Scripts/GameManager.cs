using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject lightObj;
	public static GameManager instance;
	public GameObject selectedObj= null;
    public int time = 5;


    private int timeCounter = 0;
    private float angle;
    private void Start()
    {
        StartCoroutine("passTime");
		instance = this;
    }
    private void Update()
    {
		if (Input.GetKeyDown ("escape")) {
			selectedObj = null;
		}
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
