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
    private GameObject popup;
    private GameObject resource;
    private int selfResource;
	private Vector3 tResource;
	private bool isGathering = false;
	private bool isDelivering = false;
    // 0 joy, 1 food, 2 water, 3 wood, 4 wool
    void Start ()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        StartCoroutine("live");
		tResource = transform.parent.GetComponent<Tribe> ().resource.transform.position;
        popup = GameObject.FindGameObjectWithTag("popup");

    }
    private void Update()
    {
        if (Mathf.Abs(thisAgent.destination.x - tResource.x) <= 0.1f && Mathf.Abs(thisAgent.destination.z - tResource.z) <= 0.1)
        {
            if (thisAgent.remainingDistance < 0.01f && isGathering == false)
            {
                StartCoroutine("gather");
            }

        }
        else if (Mathf.Abs(thisAgent.destination.x - transform.parent.position.x) <= 0.1f && Mathf.Abs(thisAgent.destination.z - transform.parent.position.z) <= 0.1)
        {
            if (thisAgent.remainingDistance < 0.01f && isDelivering == false)
            {
                StartCoroutine("deliver");
            }

        }
        else if (GameManager.instance.selectedTribe != null && Mathf.Abs(thisAgent.destination.x - GameManager.instance.selectedTribe.transform.position.x) <= 0.1f && Mathf.Abs(thisAgent.destination.z - GameManager.instance.selectedTribe.transform.position.z) <= 0.1 && Input.GetMouseButtonDown(0))
        {
            if (thisAgent.remainingDistance < 0.01f ) 
            {
                StartCoroutine("trade");
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
            transform.parent.GetComponent<Tribe>().changeToolSupply(1);
			StartCoroutine ("deliver");
		}
		else if (water != 0) {
			water--;
			totalAmount--;
            transform.parent.GetComponent<Tribe>().changeWaterSupply(1);
            StartCoroutine ("deliver");
		}
		else if (food != 0) {
			food--;
			totalAmount--;
            transform.parent.GetComponent<Tribe>().changeFoodSupply(1);
            StartCoroutine ("deliver");
		}
		else if (wool != 0) {
			wool--;
			totalAmount--;
            transform.parent.GetComponent<Tribe>().changeWoolSupply(1);
            StartCoroutine ("deliver");
		}
		else if (social != 0) {
			social--;
			totalAmount--;
            StartCoroutine ("deliver");
		}
    }
    IEnumerator trade()
    {
        GameObject tribe = GameManager.instance.selectedTribe;
        if( tribe.name == "Tribe_red")
        {
            social += 10;
        }
        else if (tribe.name == "Tribe_green" && tribe.GetComponent<Tribe>().getFood() >= 10 )
        {
            tribe.GetComponent<Tribe>().changeFoodSupply(-10);
            food += 10;
            // selfres -10
        }
        else if (tribe.name == "Tribe_yellow" && tribe.GetComponent<Tribe>().getTool() >= 10)
        {
            tribe.GetComponent<Tribe>().changeToolSupply(-10);
            wood += 10;
            // selfres -10
        }
        else if (tribe.name == "Tribe_blue" && tribe.GetComponent<Tribe>().getWater() >= 10)
        {
            tribe.GetComponent<Tribe>().changeWaterSupply(-10);
            water += 10;
            // selfres -10
        }
        else if (tribe.name == "Tribe_purple" && tribe.GetComponent<Tribe>().getWool() >= 10)
        {
            tribe.GetComponent<Tribe>().changeWoolSupply(-10);
            wool += 10;
            // selfres -10
        }
        yield return null;
    }
    void die()
    {
        DestroyObject(gameObject);
    }

	private void OnMouseDown()
    {
		GameManager.instance.selectedObj = gameObject;
        GameManager.instance.prevObj = gameObject;
        transform.parent.GetComponent<Tribe>().highlighter.GetComponent<Highlight>().human = transform;
        transform.parent.GetComponent<Tribe>().highlighter.SetActive(true);
        //popup.GetComponent<PopUp>().human = gameObject;

    }

}
