using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask viewM;
    public float distance = 2.9f;
    public int countHit = 2;
    void Start()
    {
    }

   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 raycastDir = (other.transform.position - transform.position);
            raycastDir.Normalize();
            RaycastHit[] coverHits;

            coverHits = Physics.RaycastAll(transform.position, raycastDir, distance);

            if (coverHits.Length <= countHit)
            {
                other.gameObject.GetComponent<ControllerPlayer>().kill();
            }
            if (coverHits.Length > 0) {

                for (int i = 0; i < coverHits.Length; i++) {
                    Debug.Log(coverHits[i].collider.name);
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

            coverHits = Physics.RaycastAll(transform.position, raycastDir, distance);

            if (coverHits.Length <= countHit)
            {
                other.gameObject.GetComponent<ControllerPlayer>().kill();
            }
            if (coverHits.Length > 0)
            {

                for (int i = 0; i < coverHits.Length; i++)
                {
                    Debug.Log(coverHits[i].collider.name);
                }
            }

        }

    }
}
