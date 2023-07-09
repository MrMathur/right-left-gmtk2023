using UnityEngine;

public class WoodenBox : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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
                // Apply force to push the box towards the l
                Debug.Log("left");
                rb.AddForce(Vector2.left * 100f, ForceMode2D.Impulse);
            } else {
                transform.position = transform.position;
                rb.velocity = Vector2.zero;
                Debug.Log("right");

            }
        }
    }
}