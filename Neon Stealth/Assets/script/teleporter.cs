using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public GameObject target;
    private bool on;
    // Start is called before the first frame update
    void Start()
    {
        on = true;
    }

    public void off() { on = false; }

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player" && on) {
            target.GetComponent<teleporter>().off();
            col.transform.position = target.transform.position;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "Player" && !on)
        {
            on = true;
        }
    }
}
