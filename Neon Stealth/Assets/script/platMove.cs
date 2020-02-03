﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platMove : MonoBehaviour
{
    public Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.Translate(movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.DetachChildren();

        }
    }
}
