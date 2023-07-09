using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCheck : MonoBehaviour
{
    private GameObject[] enemies;
    private bool exit_open;
    private bool player_near_exit;
    private int num_keys;
    private SpriteRenderer exit_sr;

    [SerializeField] private Sprite exit_door_open_normal;
    [SerializeField] private Sprite exit_door_open_haunted;
    [SerializeField] private Sprite exit_door_normal;
    [SerializeField] private Sprite exit_door_haunted;

    private GameObject environment;

    // Start is called before the first frame update
    void Start()
    {
        exit_sr = GetComponent<SpriteRenderer>();
        num_keys = GameObject.FindGameObjectsWithTag("Key").Length;
        exit_open = false;
        player_near_exit = false;
        environment = GameObject.FindWithTag("Environment");
    }

    void Update() {
        if (num_keys==0) {
            exit_open = true;
        }
        ShowDoor();

        if (exit_open && player_near_exit) {
            PlayerStats.Levels[SceneManager.GetActiveScene().buildIndex-2] = new LevelDetails(SceneManager.GetActiveScene().buildIndex-2, true);
            SceneManager.LoadScene(EnvironmentState.curr_level);
            EnvironmentState.incrementCurrLevel();
        }
    }

    private void ShowDoor() {
        EnvState current_state = environment.GetComponent<EnvironmentState>().GetState();
        if (!exit_open) {
            if (current_state == EnvState.Left) {
                exit_sr.sprite = exit_door_open_normal;
            } else if (current_state == EnvState.Right) {
                exit_sr.sprite = exit_door_open_haunted;
            }
        } else {
            if (current_state == EnvState.Left) {
                exit_sr.sprite = exit_door_normal;
            } else if (current_state == EnvState.Right) {
                exit_sr.sprite = exit_door_haunted;
            }
        }
    }

    public void DecrementKey() {
        num_keys--;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            player_near_exit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            player_near_exit = false;
        }
    }
}
