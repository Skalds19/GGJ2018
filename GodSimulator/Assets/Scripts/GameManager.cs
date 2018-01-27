using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject lightObj;
	public GameObject ptLightObj;
	public GameObject highlighter;

    public GameObject canvas;

    public static GameManager instance;
	public GameObject selectedObj= null;
    public GameObject prevObj;
    public GameObject selectedTribe = null;
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
        if (prevObj != null )
        {
            canvas.transform.GetChild(0).GetChild(4).GetComponent<Text>().text = prevObj.GetComponent<Human>().hunger.ToString();
            canvas.transform.GetChild(0).GetChild(5).GetComponent<Text>().text = prevObj.GetComponent<Human>().thirst.ToString();
            canvas.transform.GetChild(0).GetChild(6).GetComponent<Text>().text = prevObj.GetComponent<Human>().cold.ToString();
            canvas.transform.GetChild(0).GetChild(7).GetComponent<Text>().text = prevObj.GetComponent<Human>().joy.ToString();

            canvas.transform.GetChild(0).GetChild(9).GetComponent<Text>().text = prevObj.GetComponent<Human>().food.ToString();
            canvas.transform.GetChild(0).GetChild(10).GetComponent<Text>().text = prevObj.GetComponent<Human>().water.ToString();
            canvas.transform.GetChild(0).GetChild(11).GetComponent<Text>().text = prevObj.GetComponent<Human>().wool.ToString();
            canvas.transform.GetChild(0).GetChild(12).GetComponent<Text>().text = prevObj.GetComponent<Human>().social.ToString();
        }

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
