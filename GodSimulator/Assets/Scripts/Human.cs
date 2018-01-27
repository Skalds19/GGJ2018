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
    private NavMeshAgent thisAgent;

    //private Vector3 destination;
    //private bool inputActive = false;

    void Start ()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        StartCoroutine("live");
        //destination = transform.parent.GetComponent<Tribe>().resource.transform.position;

    }
    private void Update()
    {   /*
		Vector3 dir;
		float distanceThisFrame;
        if ( inputActive )
        {
			dir = thisAgent.destination - transform.position;
			distanceThisFrame = 5 * Time.deltaTime;
			if (dir.magnitude <= distanceThisFrame + 2.5)
			{   
				inputActive = false;
				destination = transform.parent.GetComponent<Tribe>().resource.transform.position;
			}
			transform.Translate(dir.normalized * distanceThisFrame, Space.World);
			return;
        }
        dir = destination - transform.position;
        distanceThisFrame = 5 * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame + 2.5)
        {   
            if ( destination == transform.parent.transform.position )
            {
                destination = transform.parent.GetComponent<Tribe>().resource.transform.position;
            }
            else
            {
                destination = transform.parent.transform.position;
            }
            
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);*/
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
    IEnumerator gather()
    {
        thisAgent.destination = transform.parent.GetComponent<Tribe>().resource.transform.position;
        yield return new WaitForSeconds(3f);
        StartCoroutine("deliver");

    }
    IEnumerator deliver()
    {
        thisAgent.destination = transform.parent.position;
        yield return new WaitForSeconds(3f);
        StartCoroutine("gather");
    }

    void die()
    {
        DestroyObject(gameObject);
    }

	private void OnMouseDown()
    {
		GameManager.instance.selectedObj = gameObject;
	}

}
