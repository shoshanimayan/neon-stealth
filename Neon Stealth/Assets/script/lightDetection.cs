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
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 raycastDir = (other.transform.position - transform.position);
            raycastDir.Normalize();
            RaycastHit[] coverHits;

            coverHits = Physics.RaycastAll(transform.position, raycastDir, 2.9f);

            if (coverHits.Length <= 2)
            {
                other.gameObject.GetComponent<ControllerPlayer>().kill();
            }
            if (coverHits.Length > 0)
            {

                for (int i = 0; i < coverHits.Length; i++)
                {
                    Debug.Log(coverHits[i].transform.gameObject);
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 raycastDir = (other.transform.position - transform.position);
            raycastDir.Normalize();
            RaycastHit[] coverHits;

            coverHits = Physics.RaycastAll(transform.position, raycastDir, 2.9f);

            if (coverHits.Length <= 2)
            {
                other.gameObject.GetComponent<ControllerPlayer>().kill();
            }
            if (coverHits.Length > 0)
            {

                for (int i = 0; i < coverHits.Length; i++) {
                    Debug.Log(coverHits[i].transform.gameObject);
                }

            }
        }

    }
}
