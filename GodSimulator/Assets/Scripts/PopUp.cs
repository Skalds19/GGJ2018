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
        
        if ( human == null )
        {
            return;
        }
        else if(human.GetComponent<Human>().food > 0 )
        {
            Human humanscript = human.GetComponent<Human>();
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
        
        if (human == null)
        {
            return;
        }
        else if (human.GetComponent<Human>().water > 0)
        {
            Human humanscript = human.GetComponent<Human>();
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
        
        if (human == null)
        {
            return;
        }
        else if (human.GetComponent<Human>().wool > 0)
        {
            Human humanscript = human.GetComponent<Human>();
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
        if (human == null)
        {
            return;
        }
        else if (human.GetComponent<Human>().social > 0)
        {
            Human humanscript = human.GetComponent<Human>();
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
