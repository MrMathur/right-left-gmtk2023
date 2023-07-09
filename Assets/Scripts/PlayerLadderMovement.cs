using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadderMovement : MonoBehaviour
{

    private bool player_near_ladder;

    private Rigidbody2D player_rb;

    [SerializeField] private float y_speed;
    private float gravityScale;
    private float dir_y;


    // Start is called before the first frame update
    void Start()
    {
        player_near_ladder = false;
        player_rb = GetComponent<Rigidbody2D>();
        gravityScale = player_rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        dir_y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() {
        if (player_near_ladder) {
            player_rb.gravityScale = 0f;
            player_rb.velocity = new Vector2(player_rb.velocity.x, dir_y * y_speed);
        } else {
            player_rb.gravityScale = gravityScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Ladder")) {
            player_near_ladder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("Ladder")) {
            player_near_ladder = false;
        }
    }
}
