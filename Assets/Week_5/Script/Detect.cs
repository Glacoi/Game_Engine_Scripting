using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    bool detected;
    GameObject target;
    public Transform enemy;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (detected)
        {
            enemy.LookAt(transform.position);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            detected = true;
            target = other.gameObject;

        }


        
    }











}
