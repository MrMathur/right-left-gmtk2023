using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSprites : MonoBehaviour
{

    private GameObject environment;

    [SerializeField] private Sprite normal_platform;
    [SerializeField] private Sprite haunted_platform;
    private SpriteRenderer platform_sr;

    private EnvState current_state;
    private EnvState previous_state;
    // Start is called before the first frame update
    void Start()
    {
        environment = GameObject.FindWithTag("Environment");
        platform_sr = GetComponent<SpriteRenderer>();
        previous_state = EnvState.Left;
    }

    // Update is called once per frame
    void Update()
    {
        current_state = environment.GetComponent<EnvironmentState>().GetState();

        if (current_state != previous_state) {
            previous_state = current_state;

            ChangeSprites(current_state);
        }
    }

    private void ChangeSprites(EnvState state) {
        if (state == EnvState.Left) {
            platform_sr.sprite = normal_platform;
        } else if (state == EnvState.Right) {
            platform_sr.sprite = haunted_platform;
        }
    }
}
