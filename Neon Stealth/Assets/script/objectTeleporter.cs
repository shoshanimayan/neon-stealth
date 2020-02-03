using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectTeleporter : MonoBehaviour
{
    public GameObject target;
    private Vector3 position;
    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        on = true;
    }

    public void off() { on = false; }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("trig");
        if (col.transform.tag != "Player" && on)
        {
            target.GetComponent<objectTeleporter>().off();
            position = new Vector3(target.transform.position.x, col.transform.position.y, target.transform.position.z);
            col.transform.position = position;
        }
        if (col.transform.tag == "Player") { col.gameObject.GetComponent<ControllerPlayer>().kill(); }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.transform.tag != "Player" && !on)
        {
            on = true;
        }
    }
}
