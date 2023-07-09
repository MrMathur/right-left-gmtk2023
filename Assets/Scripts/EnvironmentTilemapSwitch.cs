using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentTilemapSwitch : MonoBehaviour
{
    [SerializeField] private GameObject normal_environment;
    [SerializeField] private GameObject haunted_environment;
    
    private EnvState current_state;
    private EnvState previous_state;

    void Start() {
        previous_state = EnvState.Left;
    }
    // Update is called once per frame
    void Update()
    {
        current_state = GetComponent<EnvironmentState>().GetState();    

        if (current_state != previous_state) {
            previous_state = current_state;

            if (current_state == EnvState.Left) {
                normal_environment.SetActive(true);
                haunted_environment.SetActive(false);
            } else if (current_state == EnvState.Right) {
                normal_environment.SetActive(false);
                haunted_environment.SetActive(true);
            }
        }
    }
}
