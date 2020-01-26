using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    static public  bool running;


    private void Start()
    {
        running = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<ControllerPlayer>().kill();
    }
    public void deactivate()
    {
        running = false;
    }
}
