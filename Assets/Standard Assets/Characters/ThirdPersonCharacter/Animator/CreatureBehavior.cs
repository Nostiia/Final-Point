using UnityEngine;

public class CreatureBehavior : MonoBehaviour
{
    public float movementSpeed = 3f;

    private Transform player; // Reference to the player's transform

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player GameObject and get its transform
    }

    void Update()
    {
        // Move towards the player
        transform.LookAt(player.position);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Ignore collisions with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}

