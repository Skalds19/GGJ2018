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
	private Vector3 tResource;
	private bool isGathering = false;
	private bool isDelivering = false;

    void Start ()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        StartCoroutine("live");
		tResource = transform.parent.GetComponent<Tribe> ().resource.transform.position;
    }
    private void Update()
    {   
		if (Mathf.Abs(thisAgent.destination.x - tResource.x) <= 0.1f && Mathf.Abs(thisAgent.destination.z - tResource.z) <= 0.1) 
		{
			if (thisAgent.remainingDistance < 0.01f && isGathering == false) {
				StartCoroutine ("gather");
			}

		}
		if (Mathf.Abs(thisAgent.destination.x - transform.parent.position.x) <= 0.1f && Mathf.Abs(thisAgent.destination.z - transform.parent.position.z) <= 0.1) 
		{
			if (thisAgent.remainingDistance < 0.01f && isDelivering == false) {
				StartCoroutine ("deliver");
			}

		}
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
		isGathering = true;
		yield return new WaitForSeconds(1f);
		resource = transform.parent.GetComponent<Tribe> ().resource;
		if (totalAmount == inventorySize || !(Mathf.Abs(transform.position.x - tResource.x) <= 0.1f && Mathf.Abs(transform.position.z - tResource.z) <= 0.1)) {
			isGathering = false;
		}
		else if (resource.name == "Forest") {
			wood++;
			totalAmount++;
			StartCoroutine ("gather");
		}
		else if (resource.name == "Fountain") {
			water++;
			totalAmount++;
			StartCoroutine ("gather");
		}
		else if (resource.name == "Bushes") {
			food++;
			totalAmount++;
			StartCoroutine ("gather");
		}
		else if (resource.name == "Sheep") {
			wool++;
			totalAmount++;
			StartCoroutine ("gather");
		}
		else if (resource.name == "dans pisti") {
			social++;
			totalAmount++;
			StartCoroutine ("gather");
		}

    }
    IEnumerator deliver()
    {
		isDelivering = true;
		yield return new WaitForSeconds(1f);
		if (!(Mathf.Abs (transform.position.x - transform.parent.position.x) <= 0.05f && Mathf.Abs (transform.position.z - transform.parent.position.z) <= 0.05)) {
			isDelivering = false;
		}
		else if (wood != 0) {
			wood--;
			totalAmount--;
			StartCoroutine ("deliver");
		}
		else if (water != 0) {
			water--;
			totalAmount--;
			StartCoroutine ("deliver");
		}
		else if (food != 0) {
			food--;
			totalAmount--;
			StartCoroutine ("deliver");
		}
		else if (wool != 0) {
			wool--;
			totalAmount--;
			StartCoroutine ("deliver");
		}
		else if (social != 0) {
			social--;
			totalAmount--;
			StartCoroutine ("deliver");
		}
    }

    void die()
    {
        DestroyObject(gameObject);
    }

	private void OnMouseDown()
    {
		GameManager.instance.selectedObj = gameObject;
        transform.parent.GetComponent<Tribe>().highlighter.GetComponent<Highlight>().human = transform;
        transform.parent.GetComponent<Tribe>().highlighter.SetActive(true);

    }

}
