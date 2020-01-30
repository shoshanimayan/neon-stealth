using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask viewM;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            RaycastHit hit;
            if (!Physics.Linecast(other.transform.position, transform.position,out hit, viewM)) {
                if (hit.transform.gameObject.tag == "Player") {
                    hit.transform.gameObject.GetComponent<ControllerPlayer>().kill();
                }
              

                Debug.Log("hit");
            }
            
        }
    }
}
