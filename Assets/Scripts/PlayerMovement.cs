using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject right_player;
    [SerializeField] private GameObject left_player;

    private Rigidbody2D player_rb;
    [SerializeField] private float x_speed;
    private float dir_x;

    private void Start() {
        dir_x = 0;
        player_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dir_x = Input.GetAxis("Horizontal");

        if (dir_x > 0) ActivateRightPlayer();
        else if (dir_x < 0) ActivateLeftPlayer();
    }

    private void FixedUpdate() {
        player_rb.velocity = new Vector2(dir_x * x_speed, player_rb.velocity.y);
    }

    private void ActivateRightPlayer() {
        right_player.SetActive(true);
        left_player.SetActive(false);
    }


    private void ActivateLeftPlayer() {
        right_player.SetActive(false);
        left_player.SetActive(true);        
    }
}
