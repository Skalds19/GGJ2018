using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour 
{
	public GameObject highlighter;

	private void OnMouseDown()
	{
		highlighter.SetActive (false);
	}
}
