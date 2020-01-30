using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "box" || collision.gameObject.tag == "yellow")
        {

            Destroy(gameObject);
        }
    }
}
