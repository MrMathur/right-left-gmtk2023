using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentExteriorChange : MonoBehaviour
{

    [SerializeField] private Sprite normal_bg;
    [SerializeField] private Sprite haunted_bg;
    private SpriteRenderer bgex_sr;

    private EnvState current_state;
    private EnvState previous_state;

    private GameObject environment;
    // Start is called before the first frame update
    void Start()
    {
        bgex_sr = GetComponent<SpriteRenderer>();
        environment = GameObject.FindWithTag("Environment");
        previous_state = EnvState.Left;
    }

    // Update is called once per frame
    void Update()
    {
        current_state = environment.GetComponent<EnvironmentState>().GetState();

        if (current_state != previous_state) {
            previous_state = current_state;

            ChangeBackground(current_state);
        }
    }

    private void ChangeBackground(EnvState state) {
        if (state == EnvState.Left) {
            bgex_sr.sprite = normal_bg;
        } else if (state == EnvState.Right) {
            bgex_sr.sprite = haunted_bg;
        }
    }
}
