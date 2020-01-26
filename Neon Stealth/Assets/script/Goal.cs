using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter(Collider trig)
    {
        if (trig.transform.tag == "Player")
        {
            Debug.Log(SceneManager.GetActiveScene().name);
        }
    }
}
