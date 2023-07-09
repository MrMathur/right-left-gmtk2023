using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    private GameObject exit;
    private bool isTriggered = false;
    void Start()
    {
        exit = GameObject.FindWithTag("Exit");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Perform the action triggered by the key collision
            if (!isTriggered) {
                isTriggered = true;
                DecrementKey();
                Destroy(gameObject);
            }

            // Destroy the key GameObject
        }
    }

    private void DecrementKey()
    {
        // Add your desired action logic here
        exit.GetComponent<ExitCheck>().DecrementKey();
    }
}