using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    [SerializeField] private GameObject haunted_go;
    [SerializeField] private GameObject normal_go;

    private GameObject environment;
    private EnvState current_state;
    private EnvState previous_state;

    [SerializeField] float max_volume;

    // Start is called before the first frame update
    void Start()
    {
        environment = GameObject.FindWithTag("Environment");
        previous_state = environment.GetComponent<EnvironmentState>().GetState();
        normal_go.GetComponent<AudioSource>().volume = max_volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnvironmentState.play_music) {
            current_state = environment.GetComponent<EnvironmentState>().GetState();


            ChangeMusic(current_state);
        } else {
            haunted_go.GetComponent<AudioSource>().volume = 0;
            normal_go.GetComponent<AudioSource>().volume = 0;            
        }
    }

    private void ChangeMusic(EnvState state) {
        if (state == EnvState.Right) {
            haunted_go.GetComponent<AudioSource>().volume = max_volume;
            normal_go.GetComponent<AudioSource>().volume = 0;
        } else if (state == EnvState.Left) {
            haunted_go.GetComponent<AudioSource>().volume = 0;
            normal_go.GetComponent<AudioSource>().volume = max_volume;
        }
    }
}
