using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingDoor : MonoBehaviour
{
    
    private bool hasExecuted = false;
    public GameObject objectToShow;

    public void Start()
    {
        objectToShow.SetActive(false);

    }
    public void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");


        if (enemies.Length == 0)
        {
            if (!hasExecuted) //makes it run for one time in update method
            {

                objectToShow.SetActive(true);


                hasExecuted = true;
            }
           
            
        }

    }
}


