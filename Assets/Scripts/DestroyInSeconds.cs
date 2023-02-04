using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    public float seconds = 0.5f;

    private void Start()
    {
        Destroy(gameObject, seconds);
    }
}
