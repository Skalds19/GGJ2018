using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{

    public float hunger  = 100;
    public float thirst  = 100;
    public float fatigue = 100;
    public float cold    = 100;
    public float joy     = 100;
	public NavMeshAgent agent;


    void Start ()
    {
		agent = GetComponent<NavMeshAgent> ();
        StartCoroutine("live");
    }

    IEnumerator live()
    {
        yield return new WaitForSeconds(1f);
        hunger -= 1;
        thirst -= 1;
        fatigue -= 1;
        cold -= 1;
        joy -= 1;
        if ( hunger > 0 && thirst > 0 && fatigue > 0 && cold > 0 && joy > 0 )
        {
            StartCoroutine("live");
        }
        else
        {
            die();
        }
    }
    void die()
    {
        DestroyObject(gameObject);
    }

	private void OnMouseDown(){
		if (GameManager.instance.selectedObj == null)
			GameManager.instance.selectedObj = gameObject;
		else {
			agent.destination = GameManager.instance.selectedObj.transform.position;
			GameManager.instance.selectedObj = null;
		}
	}

}
