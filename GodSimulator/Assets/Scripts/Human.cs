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

	public int inventorySize = 20;
	public int wood = 0;
	public int food = 0;
	public int water = 0;
	public int wool = 0;
	public int social = 0;
	public int totalAmount = 0;
	private NavMeshAgent thisAgent;
	private GameObject resource;

    //private Vector3 destination;
    //private bool inputActive = false;

    void Start ()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        StartCoroutine("live");
        //destination = transform.parent.GetComponent<Tribe>().resource.transform.position;

    }
    private void Update()
    {   
		if (thisAgent.destination == transform.parent.GetComponent<Tribe> ().resource.transform.position) {
			Debug.Log ("gather");
			if (thisAgent.remainingDistance <= 0.01f)
				StartCoroutine ("gather");
		}
		/*
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
		resource = transform.parent.GetComponent<Tribe> ().resource;
		if (resource.name == "Forest") {
			if (totalAmount < 20) {
				wood++;
				totalAmount++;
			}
			else {
				StopCoroutine ("gather");
			}
		}
		if (resource.name == "Fountain") {
			if (totalAmount < 20) {
				water++;
				totalAmount++;
			}
			else {
				StopCoroutine ("gather");
			}
		}
		if (resource.name == "Bushes") {
			if (totalAmount < 20) {
				food++;
				totalAmount++;
			}
			else {
				StopCoroutine ("gather");
			}
		}
		if (resource.name == "Sheep") {
			if (totalAmount < 20) {
				food++;
				totalAmount++;
			}
			else {
				StopCoroutine ("gather");
			}
		}
		if (resource.name == "dans pisti") {
			if (totalAmount < 20) {
				social++;
				totalAmount++;
			}
			else {
				StopCoroutine ("gather");
			}
		}
        yield return new WaitForSeconds(1f);

    }
    IEnumerator deliver()
    {
        thisAgent.destination = transform.parent.position;
        yield return new WaitForSeconds(3f);
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
