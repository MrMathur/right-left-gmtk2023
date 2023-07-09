using UnityEngine;

public class WoodenBox : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        player = GameObject.FindWithTag("Player");
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the collision occurs from the right side
            float playerPosX = collision.transform.position.x;
            float boxPosX = transform.position.x;
            if (playerPosX > boxPosX)
            {   
                if (rb.velocity.x <0.1f){
                    player.GetComponent<Animator>().SetBool("isPushing", false);
                }

                // Apply force to push the box towards the left
                rb.AddForce(Vector2.left * 100f, ForceMode2D.Impulse);
                player.GetComponent<Animator>().SetBool("isPushing", true);
            } else {
                transform.position = transform.position;
                rb.velocity = Vector2.zero;

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
         if (collision.gameObject.CompareTag("Player")) {
            player.GetComponent<Animator>().SetBool("isPushing", false);
         }
    }
}