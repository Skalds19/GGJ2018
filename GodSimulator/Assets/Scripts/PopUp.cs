using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour {

    public GameObject human;

    private void Update()
    {
        human = GameManager.instance.selectedObj;
    }
    public void eat()
    {
        Human humanscript = human.GetComponent<Human>();
        if ( human == null )
        {
            return;
        }
        else if( humanscript.food > 0 )
        {
            humanscript.food--;
            humanscript.totalAmount--;
            humanscript.hunger += 10;
            if ( humanscript.hunger > 100 )
            {
                humanscript.hunger = 100;
            }
        }
        else
        {

        }
    }
    public void drink()
    {
        Human humanscript = human.GetComponent<Human>();
        if (human == null)
        {
            return;
        }
        else if (humanscript.water > 0)
        {
            humanscript.water--;
            humanscript.totalAmount--;
            humanscript.thirst += 10;
            if (humanscript.thirst > 100)
            {
                humanscript.thirst = 100;
            }
        }
        else
        {

        }
    }
    public void warm()
    {
        Human humanscript = human.GetComponent<Human>();
        if (human == null)
        {
            return;
        }
        else if (humanscript.wool > 0)
        {
            humanscript.wool--;
            humanscript.totalAmount--;
            humanscript.cold += 10;
            if (humanscript.cold > 100)
            {
                humanscript.cold = 100;
            }
        }
        else
        {

        }
    }
    public void fun()
    {
        Human humanscript = human.GetComponent<Human>();
        if (human == null)
        {
            return;
        }
        else if (humanscript.social > 0)
        {
            humanscript.social--;
            humanscript.totalAmount--;
            humanscript.joy += 10;
            if (humanscript.joy > 100)
            {
                humanscript.joy = 100;
            }
        }
        else
        {

        }
    }
}
