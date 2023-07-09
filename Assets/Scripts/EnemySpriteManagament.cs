using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteManagament : MonoBehaviour
{

    private GameObject environment;
    private Rigidbody2D enemy_rb;
    private BoxCollider2D enemy_bc;
    private float gravityScale;
    private Animator enemy_anim;

    private EnvState previous_state;
    // Start is called before the first frame update
    void Start()
    {
        enemy_rb = GetComponent<Rigidbody2D>();
        enemy_bc = GetComponent<BoxCollider2D>();
        previous_state = EnvState.Left;
        gravityScale = enemy_rb.gravityScale;
        environment = GameObject.FindWithTag("Environment");
        Physics2D.IgnoreLayerCollision(9, 10, false);
        enemy_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnvState currentState = environment.GetComponent<EnvironmentState>().GetState();

        if (currentState != previous_state) {
            previous_state = currentState;

            EnemySpriteChange(currentState);
            EnemyPhysicsChange(currentState);
        }
    }

    private void EnemySpriteChange(EnvState currentState) {
        if (currentState == EnvState.Left) {
            enemy_anim.SetBool("Ghost", false);
        } else if (currentState == EnvState.Right) {
            enemy_anim.SetBool("Ghost", true);
        }
    }

    private void EnemyPhysicsChange(EnvState currentState) {
        if (currentState == EnvState.Left) {
            enemy_rb.gravityScale = gravityScale;
            Physics2D.IgnoreLayerCollision(9, 10, false);
        } else if (currentState == EnvState.Right) {
            enemy_rb.gravityScale = 0f;
            Physics2D.IgnoreLayerCollision(9, 10);
        }
    }
}
