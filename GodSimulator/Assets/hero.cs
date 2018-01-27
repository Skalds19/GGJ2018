using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.instance.selectedObj = gameObject.transform.parent.gameObject;
    }
}
