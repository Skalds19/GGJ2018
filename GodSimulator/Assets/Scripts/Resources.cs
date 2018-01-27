using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Resources : MonoBehaviour {
    public GameObject highlighter;
	private NavMeshAgent agent;
	private GameObject resource;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}	

	private void OnMouseDown(){
		if (GameManager.instance.selectedObj != null) {
			resource = GameManager.instance.selectedObj.GetComponent<Human> ().transform.parent.GetComponent<Tribe> ().resource;
			if (gameObject.name == resource.name) {
				agent = GameManager.instance.selectedObj.GetComponent<NavMeshAgent> ();
				agent.destination = transform.position;
				GameManager.instance.selectedObj = null;
                highlighter.SetActive(false);
			}
		}
	}
}
