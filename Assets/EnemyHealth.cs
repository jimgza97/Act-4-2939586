using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 20;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
