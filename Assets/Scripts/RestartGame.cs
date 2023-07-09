using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            SceneManager.LoadScene(0);
            EnvironmentState.curr_level = 2;
        }
    }
}
