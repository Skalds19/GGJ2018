using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject lightObj;
	public GameObject ptLightObj;
	public GameObject highlighter;
    public static GameManager instance;
	public GameObject selectedObj= null;
    public int time;


    private int timeCounter = 0;
    private float angle;
    private void Start()
    {
        time = 5;

        StartCoroutine("passTime");
		instance = this;
    }
    private void Update()
    {
		if (Input.GetKeyDown ("escape"))
        {
			selectedObj = null;
			highlighter.SetActive (false);
		}
    }

    IEnumerator passTime()
    {
        
        yield return new WaitForSeconds(1/8f);
        timeCounter++;
        if (timeCounter == 40)
        {
            timeCounter = 0;
            time++;
        }
        if ( time > 23 )
        {
            time = 0;
            lightObj.SetActive(false);
            //ptLightObj.SetActive(true);
        }
        else if ( time < 5 )
        {
            ptLightObj.transform.GetComponent<Light>().intensity -= 1/200;
        }
        else if ( time == 5 )
        {
            Quaternion tmp = lightObj.transform.rotation;
            tmp.x = 0.18f;
            lightObj.transform.rotation = tmp;
            lightObj.SetActive(true);
            //ptLightObj.SetActive(false);
        }
        else if ( time > 5)
        {   
            if ( time > 19 )
            {
                ptLightObj.transform.GetComponent<Light>().intensity += 1 / 160;
            }
            Quaternion tmp = lightObj.transform.rotation;
            tmp.x += timeCounter / 5;
            lightObj.transform.rotation = Quaternion.Lerp(lightObj.transform.rotation, tmp, Time.deltaTime / 30);
        }
        StartCoroutine("passTime");

    }
}
