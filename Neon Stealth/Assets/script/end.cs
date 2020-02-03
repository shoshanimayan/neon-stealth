using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.anyKeyDown)
            SceneManager.LoadScene(0);
    }
}
