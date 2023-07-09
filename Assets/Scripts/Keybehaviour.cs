using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    private GameObject exit;
    void Start()
    {
        exit = GameObject.FindWithTag("Exit");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        Debug.Log(other.CompareTag("Player"));
        if (other.CompareTag("Player"))
        {
            // Perform the action triggered by the key collision
            DecrementKey();

            // Destroy the key GameObject
            Destroy(gameObject);
             Debug.Log("object destroyed");
        }
    }

    private void DecrementKey()
    {
        // Add your desired action logic here
        exit.GetComponent<ExitCheck>().DecrementKey();
        Debug.Log("actionTriggered");
    }
}