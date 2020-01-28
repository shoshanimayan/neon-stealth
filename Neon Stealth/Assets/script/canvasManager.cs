using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class canvasManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject Player;
    public GameObject startScreen;
    private ControllerPlayer pc;

    private void Start()
    {
        pc = Player.GetComponent<ControllerPlayer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!pc.GetAlive()){
            panel.SetActive(true);
            Player.SetActive(false);

        }
        if (panel.active) {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (startScreen.active)
        {
            if (Input.anyKeyDown)
            {
                startScreen.SetActive(false);
            }
        }
        else {
            pc.StartUp();
        }
    }
}
