using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingDoor : MonoBehaviour
{
    public GameObject doorPrefab; // The door prefab to be instantiated
    public Vector2 DoorSpawnPoint;
    private bool hasExecuted = false;


    public void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");


        if (enemies.Length == 0)
        {
            if (!hasExecuted) //makes it run for one time in update method
            {
                
                Instantiate(doorPrefab, DoorSpawnPoint, Quaternion.identity);
                Debug.Log("This code runs once in the Update method.");

                hasExecuted = true;
            }
           
            
        }

    }
}


