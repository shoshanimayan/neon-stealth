using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    public GameObject toMove;
    public Vector3 movement;
    public bool reverse = false;
    private bool move;
    private bool revStart;
    private bool active = true;
    // Start is called before the first frame update
    private void Start()
    {
        
        move = false;
        revStart = false;
    }
    private void Update()
    {
        if (move) {
            Debug.Log("Moving");
            
            toMove.transform.Translate(movement);
            move = false;
            if (revStart) {
                revStart = false;
                movement = movement * -1;
            }
            if (!reverse) {
                active = false;
                Behaviour halo = (Behaviour)GetComponent("Halo");
                halo.enabled = false;
                GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
                GetComponent<Renderer>().material.SetColor("_TintColor", Color.grey);

            }
        }
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if ((col.transform.tag == "Player" || col.transform.tag == "box")&& active)
        {
            Debug.Log("move");
            move = true;
            revStart = false;

        }
    }


    private void OnTriggerExit(Collider col)
    {
        if ((col.transform.tag == "Player" || col.transform.tag == "box") && reverse)
        {
            movement = movement * -1;
            move = true;
            revStart = true;
        }
    }
}
