using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float x;
    public float x2;
    public float z;
    public float z2;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        if ((player.transform.position + offset).x < x && (player.transform.position + offset).x > x2)
        {
          //  Debug.Log("1");
            if ((player.transform.position + offset).z < z2 && (player.transform.position + offset).z > z) {


            //    Debug.Log("2");

                transform.position = player.transform.position + offset;

                


            }



        }
    }
}
