using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEnvStateChange : MonoBehaviour
{

    private bool player_near_switch;

    private GameObject environment;

    private GameObject[] triggered_platforms;

    [SerializeField] private bool conditional_switch;

    [SerializeField] private EnvState active_state;

    private BoxCollider2D switch_bc;
    private SpriteRenderer switch_sr;

    private Animator anim;

    private AudioSource click_sound;

    void Start() {
        player_near_switch = false;
        environment = GameObject.FindWithTag("Environment");
        triggered_platforms =  GameObject.FindGameObjectsWithTag("TriggeredPlatform");
        switch_bc = GetComponent<BoxCollider2D>();
        switch_sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        click_sound = GetComponent<AudioSource>();
    }

    void Update() {
        if (player_near_switch && Input.GetButtonDown("Jump")) {
            FlipSwitch();
            MoveAllTriggeredPlatforms();
        }

        if (conditional_switch) {
            ShowSwitchOnCondition();
        }
    }

    private void ShowSwitchOnCondition() {
        EnvState currentState = environment.GetComponent<EnvironmentState>().GetState();
        if (active_state == currentState) {
            switch_bc.enabled = true;
            switch_sr.enabled = true;
        } else {
            switch_bc.enabled = false;
            switch_sr.enabled = false;
        }
    }

    private void FlipSwitch() {
        anim.SetTrigger("SwitchHit");
        EnvState currentState = environment.GetComponent<EnvironmentState>().GetState();
        if (currentState == EnvState.Left) {
            environment.GetComponent<EnvironmentState>().SetState(EnvState.Right);
        } else if (currentState == EnvState.Right) {
            environment.GetComponent<EnvironmentState>().SetState(EnvState.Left);
        }
        click_sound.Play();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            player_near_switch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            player_near_switch = false;
        }
    }

    private void MoveAllTriggeredPlatforms() {
        if (triggered_platforms.Length > 0) {
            for (int i = 0; i < triggered_platforms.Length; i++) {
                triggered_platforms[i].GetComponent<PlatformTriggeredMovement>().PlatformMoveToNext();
            }
        }
    }
}
