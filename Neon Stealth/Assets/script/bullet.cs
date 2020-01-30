using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "red")
        {
            Debug.Log("hit");
        }
        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);

    }
}