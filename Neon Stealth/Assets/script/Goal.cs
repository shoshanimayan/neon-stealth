using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject screen;
    private bool transition = false;

    private void Update()
    {
        if (transition)
        {
            int level = SceneManager.GetActiveScene().buildIndex;
            if (Input.anyKeyDown)
                SceneManager.LoadScene(level + 1);
        }
    }
    void OnTriggerEnter(Collider trig)
    {
        if (trig.transform.tag == "Player")
        {
            screen.SetActive(true);
            transition = true;
            trig.gameObject.GetComponent<ControllerPlayer>().win();
            
           
        }
    }
}
