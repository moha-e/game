using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Apply damage to player
            TakeDamage(10);
        }
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            // Load the game over scene
            SceneManager.LoadScene(7);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
